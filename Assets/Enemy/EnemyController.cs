using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public ExplosionController Explosion;
    [SerializeField] private GameObject EnemyShot;
    Vector3 dir = Vector3.zero; //移動方向
    float speed;            //移動速度
    float span;
    float delta;
    int random;

    void Start() {
        //寿命4秒
        Destroy(gameObject, 4f);
        span = Random.Range(1, 3);
        random = Random.Range(0, 10);
        speed = 5;
    }

    void Update() {
        //移動方向を決定
        dir = Vector3.left;

        //上下運動
        if (random < 3) dir.y = Mathf.Sin(speed * Time.time);

        //現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;

        //敵弾
        delta += Time.deltaTime;
        if (delta > span) {
            delta = 0;
            GameObject go = Instantiate(EnemyShot);
            go.transform.position = transform.position;
            span = Random.Range(1, 3);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;

        if (obj.tag == "Player" || obj.tag == "MyShot") {
            //プレイヤーに当たったら-1000km減らす
            if (obj.tag == "Player") {
                GameDirector.kyori -= 1000;
            } else {
                Destroy(obj);
                //倒したら+200km増やす
                GameDirector.kyori += 200;
            }

            //消去時にエフェクトを出す
            Instantiate(Explosion, transform.localPosition, Quaternion.identity);
            //何か他のオブジェクトと重なったら消去
            Destroy(gameObject);
        }
    }
}










