using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    [SerializeField] GameObject myShot;
    [SerializeField] Text shotLevel;

    Animator anim;                  //アニメーターコンポーネントの情報を保存する変数
    Vector3 dir = Vector3.zero;     //移動方向を保存する変数

    float delta;

    int level;                      //弾のレベルを保存する変数
    float speed;                    //プレイヤーの移動速度を保存する変数
    float span;                     //弾の召喚時間間隔を保存する変数
    float shotSpeed;                //弾の速度を保存する変数

    public int Level {
        get { return level; }
        set { 
            level = value;
            level = Mathf.Clamp(level, 0, 12);
        }
    }

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    public float MyShotSpan {
        get { return span; }
        set { span = value; }
    }

    public float MyShotSpeed {
        get { return shotSpeed; }
        set { shotSpeed = value; }
    }

    void Start() {
        //アニメーターコンポーネントの情報を保存
        anim = GetComponent<Animator>();

        span = 0.25f;
        delta = 0;
        shotSpeed = 10;
        speed = 10f;
        level = 0;
    }

    void Update() {
        //弾レベル変更
        if (Input.GetKeyDown(KeyCode.C)) {
            level++;
            if (level == 13) {
                level = 0;
            }
        }
        shotLevel.text = ($"ShotLevel: {level.ToString("D2")}");

        //弾を生成する
        delta += Time.deltaTime;
        if (delta > span && Input.GetButton("Shot")) {
            delta = 0f;
            //レベルによって出す弾数
            for (int i = -level; i < level + 1; i++) {
                //プレイヤーの現在地を取得
                Vector3 p = transform.position;

                //プレイヤーの回転角度を取得
                Quaternion rot = Quaternion.identity;
                rot.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);

                //現在地と角度をセット
                Instantiate(myShot, p, rot);
            }
            SeManager.Instance.Play("se_chun1");
        }

        //移動方向をセット
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized * speed * Time.deltaTime;

        //画面内移動制限
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        //アニメーション設定
        if(dir.y == 0) {
            //アニメーションクリップ【Player】を再生
            anim.Play("Player");
        } else if(dir.y == 1) {
            anim.Play("PlayerL");
        } else if(dir.y == -1) {
            anim.Play("PlayerR");
        }
    }
}
