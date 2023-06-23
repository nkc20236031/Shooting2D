using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public EffectController Explosion;
    [SerializeField] GameObject EnemyShot;
    Vector3 dir = Vector3.zero;                 //移動方向
    int attack;
    int random;
    float span;
    float delta;
    float speed;                                //移動速度
    float rad;

    void Start() {
        attack = 0;
        random = Random.Range(0, 10);
        span = 2f;
        speed = 5f;
        rad = Time.time;
        if (random < 1) {
            Destroy(gameObject, 10f);
        } else {
            Destroy(gameObject, 5f);
        }
    }

    void Update() {
        //移動方向を決定
        dir = Vector3.left;

        if (random < 3) {   //上下移動
            dir.y = Mathf.Sin(rad + Time.time * speed);
        } else {            //攻撃
            delta += Time.deltaTime;
            if (delta > span) {
                delta = 0;
                Instantiate(EnemyShot, transform.position, transform.rotation);
            }
        }

        //現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            //敵に当たったら-1000km減らす
            GameDirector.kyori -= 500;
            GameDirector.hp -= 5;

            //消去時にエフェクトを出す
            Explosion.transform.localScale = new Vector3(2f, 2f, 0);
            Instantiate(Explosion, transform.localPosition, Quaternion.identity);

            //何か他のオブジェクトと重なったら消去
            Destroy(gameObject);
        } else if (obj.tag == "MyShot") {
            attack++;
            Destroy(obj);
            if (attack == 3) {
                //倒したら+200km増やす
                GameDirector.kyori += 200;

                //消去時にエフェクトを出す
                Explosion.transform.localScale = new Vector3(2f, 2f, 0);
                Instantiate(Explosion, transform.localPosition, Quaternion.identity);

                //何か他のオブジェクトと重なったら消去
                Destroy(gameObject);
            }
        }
    }
}
