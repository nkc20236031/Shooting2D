using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public ExplosionController Explosion;
    [SerializeField] GameObject EnemyShot;
    Vector3 dir = Vector3.zero;                 //移動方向
    int random;
    float span;
    float delta;
    float speed;                                //移動速度
    float rad;

    void Start() {
        Destroy(gameObject, 5f);

        random = Random.Range(0, 10);
        span = 2f;
        speed = 5f;
        rad = Time.time;
    }

    void Update() {
        //移動方向を決定
        dir = Vector3.left;

        //上下運動
        if (random < 3) {
            dir.y = Mathf.Sin(rad + Time.time * speed);
        }

        //現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;

        //敵弾
        delta += Time.deltaTime;
        if (delta > span) {
            delta = 0;
            Instantiate(EnemyShot, transform.position, transform.rotation);
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
