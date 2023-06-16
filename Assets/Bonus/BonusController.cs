using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour {
    Vector3 dir = Vector3.zero;
    int random;
    float speed;

    void Start() {
        //マテリアルカラーの変更
        random = Random.Range(0, 3);
        Material mat = GetComponent<Renderer>().material;
        switch (random) {
            case 0:
                mat.color = Color.red;      //赤玉
                break;
            case 1:
                mat.color = Color.green;    //緑玉
                break;
            case 2:
                mat.color = Color.blue;     //青玉
                break;
        }
        speed = 5f;
    }

    void Update() {
        dir = Vector3.down;
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            switch (random) {
                case 0: Red();   break;
                case 1: Green(); break;
                case 2: Blue();  break;
            }
            Destroy(gameObject);
        }
    }

    //ショットUP
    void Red() {
        MyShotGenerator.level += (MyShotGenerator.level == 12)? 0:1;
    }

    //スピードUP
    void Green() {
        PlayerController.speed += (PlayerController.speed < 20)? 2:0;
    }

    //性能ダウン
    void Blue() {
        MyShotGenerator.level = 0;
        PlayerController.speed = 10;
    }
}
