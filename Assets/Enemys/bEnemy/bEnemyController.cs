using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bEnemyController : MonoBehaviour {
    public EffectController Explosion;
    GameDirector gd;

    Vector3 dir = Vector3.zero;

    float speed;

    void Start() {
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        speed = 5f;

        Destroy(gameObject, 5);
    }

    void Update() {
        dir = Vector3.left;
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D obj) {
        switch (obj.tag) {
            case "Player":
                //“G‚É“–‚½‚Á‚½‚çScore: -1500, HP: -20Œ¸‚ç‚·
                gd.Score -= 1500;
                gd.HP -= 20;
                break;
            case "MyShot":
                Destroy(obj.gameObject);
                break;
        }
    }
}
