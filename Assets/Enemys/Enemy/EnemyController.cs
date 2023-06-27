using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public EffectController Explosion;
    GameDirector gd;
    
    Vector3 dir = Vector3.zero;                 //移動方向

    int attack;
    int random;
    float speed;                                //移動速度
    float rad;

    void Start() {
        attack = 0;
        speed = 5f;
        rad = Time.time;

        random = Random.Range(0, 10);
        if (random < 1) {
            Destroy(gameObject, 10f);
        } else {
            Destroy(gameObject, 5f);
        }

        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    void Update() {
        //移動方向を決定
        dir = Vector3.left;

        if (random < 3) {   //上下移動
            dir.y = Mathf.Sin(rad + Time.time * speed);
        }

        //現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            //敵に当たったら-500減らす
            gd.Score -= 500;
            gd.HP -= 10;

            //消去時にエフェクトを出す
            Explosion.transform.localScale = new Vector3(2f, 2f, 0);
            Instantiate(Explosion, transform.localPosition, Quaternion.identity);

            //何か他のオブジェクトと重なったら消去
            Destroy(gameObject);
        } else if (obj.tag == "MyShot") {
            attack++;
            Destroy(obj);
            if (attack == 3) {
                //倒したら+200増やす
                gd.Score += 200;

                //消去時にエフェクトを出す
                Explosion.transform.localScale = new Vector3(2f, 2f, 0);
                Instantiate(Explosion, transform.localPosition, Quaternion.identity);

                //何か他のオブジェクトと重なったら消去
                Destroy(gameObject);
            }
        }
    }
}
