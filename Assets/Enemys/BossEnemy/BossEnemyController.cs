using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : MonoBehaviour {
    public EffectController Explosion;
    GameDirector gd;

    [SerializeField] GameObject EnemyShot;
    GameObject player;
    Vector3 dir = Vector3.zero;

    int attack;
    float speed;                            //移動速度
    float rad;
    float span;
    float delta;
    
    void Start() {
        attack = 0;
        speed = 5f;
        rad = Time.time;
        span = 0.5f;
        delta = 0;

        Destroy(gameObject, 300f);

        player = GameObject.Find("Player");

        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>(); ;
    }

    void Update() {
        dir.y = Mathf.Sin(rad + Time.time * speed);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(7, dir.y, 0), speed * Time.deltaTime);

        //移動制限
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        //弾を生成する
        delta += Time.deltaTime;
        if (delta > span) {
            delta = 0f;
            //現在地を取得
            Vector3 p = transform.position;

            //回転角度を取得
            Quaternion rot = Quaternion.identity;
            rot.eulerAngles = transform.rotation.eulerAngles;

            //現在地と角度をセット
            Instantiate(EnemyShot, p, rot);

            span = Random.Range(0.5f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            gd.Score -= 1500;
            gd.HP -= 25;
        } else if (obj.tag == "MyShot") {
            attack++;
            Destroy(obj);
            if (attack == 300) {
                Explosion.transform.localScale = new Vector3(3f, 3f, 0);
                Instantiate(Explosion, transform.localPosition, Quaternion.identity);
                
                gd.Score += 5000;
                
                Destroy(gameObject);
            }
        }
    }
}
