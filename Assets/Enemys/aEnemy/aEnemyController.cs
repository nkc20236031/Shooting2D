using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aEnemyController : MonoBehaviour {
    public EffectController Explosion;
    [SerializeField] GameObject EnemyShot;
    GameObject player;
    int attack;

    void Start() {
        player = GameObject.Find("Player");
        attack = 0;

        Destroy(gameObject, 10f);
    }

    void Update() {
        //追従
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 4f * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player" || obj.tag == "MyShot") {
            switch (obj.tag) {
                case "Player":
                    //敵に当たったら-1000km減らす
                    GameDirector.kyori -= 1000;
                    GameDirector.hp -= 20;

                    //消去時にエフェクトを出す
                    Explosion.transform.localScale = new Vector3(2f, 2f, 0);
                    Instantiate(Explosion, transform.localPosition, Quaternion.identity);

                    Destroy(gameObject);
                    break;
                case "MyShot":
                    attack++;
                    Destroy(obj);
                    //5回攻撃が当たったら
                    if (attack == 5) {
                        //消去時にエフェクトを出す
                        Explosion.transform.localScale = new Vector3(2.5f, 2.5f, 0);
                        Instantiate(Explosion, transform.localPosition, Quaternion.identity);

                        //何か他のオブジェクトと重なったら消去
                        Destroy(gameObject);

                        //倒したら+200km増やす
                        GameDirector.kyori += 500;
                    }
                    break;
            }
        }
    }
}
