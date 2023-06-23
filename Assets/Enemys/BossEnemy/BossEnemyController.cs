using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : MonoBehaviour {
    public EffectController Explosion;
    int attack;

    void Start() {
        attack = 0;
    }

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(5, 0, 0), 2f * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            GameDirector.kyori -= 1500;
            GameDirector.hp -= 25;
        } else if (obj.tag == "MyShot") {
            attack++;
            Destroy(obj);
            if (attack == 300) {
                Explosion.transform.localScale = new Vector3(5f, 5f, 0);
                Instantiate(Explosion, transform.localPosition, Quaternion.identity);
                
                GameDirector.kyori += 5000;
                
                Destroy(gameObject);
            }
        }
    }
}
