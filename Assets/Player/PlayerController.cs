using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Vector2 range;
    [SerializeField] private float speed;
    Animator anim;
    Vector3 dir = Vector3.zero;     //移動方法を保存する変数

    void Start() {
        //アニメーターコンポーネントの情報を保存
        anim = GetComponent<Animator>();
    }

    void Update() {
        //移動方向をセット
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;

        //画面内移動制限
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -range.x, range.x);
        pos.y = Mathf.Clamp(pos.y, -range.y, range.y);
        transform.position = pos;

        //アニメーション設定
        if(dir.y == 0) {
            //アニメーションクリップ【Player】を再生
            anim.Play("Player");
        } else if(dir.y > 0) {
            anim.Play("PlayerL");
        } else if( dir.y < 0) {
            anim.Play("PlayerR");
        }
    }
}
