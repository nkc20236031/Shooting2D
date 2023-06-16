using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public ExplosionController Explosion;
    [SerializeField] GameObject EnemyShot;
    Vector3 dir = Vector3.zero;                 //移動方向
    int random;
    float span;
    float delta;
    float speed;                                //移動速度

    void Start() {
        Destroy(gameObject, 4f);

        random = Random.Range(0, 10);
        span = Random.Range(1, 3);
        speed = 5;
    }

    void Update() {
        //移動方向を決定
        dir = Vector3.left;

        //上下運動
        if (random < 3) {
            dir.y = Mathf.Sin(speed * Time.time);
        }

        //現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;

        //敵弾
        delta += Time.deltaTime;
        if (delta > span) {
            delta = 0;

            //敵弾を生成する
            GameObject go = Instantiate(EnemyShot);
            go.transform.position = transform.position;
            span = Random.Range(1, 3);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player" || obj.tag == "MyShot") {
            switch (obj.tag) {
                case "Player":
                    //敵に当たったら-1000km減らす
                    GameDirector.kyori -= 1000;
                    break;
                case "MyShot":
                    //倒したら+200km増やす
                    GameDirector.kyori += 200;
                    Destroy(obj);
                    break;
            }

            //消去時にエフェクトを出す
            Instantiate(Explosion, transform.localPosition, Quaternion.identity);

            //何か他のオブジェクトと重なったら消去
            Destroy(gameObject);
        }
    }
}










