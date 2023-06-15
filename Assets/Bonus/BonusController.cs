using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour {
    [SerializeField] private float speed;
    int random;

    void Start() {
        //マテリアル（色）変更
        Material mat = GetComponent<Renderer>().material;
        random = Random.Range(0, 3);
        switch (random) {
            case 0:
                mat.color = Color.red;
                break;
            case 1:
                mat.color = Color.green;
                break;
            case 2:
                mat.color = Color.blue;
                break;
        }
    }

    void Update() {
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            switch (random) {
                case 0: Red(); break;
                case 1: Green(); break;
                case 2: Blue(); break;
            }
            Destroy(gameObject);
        }
    }

    //ショットUP
    void Red() {
        MyShotGenerator.level++;
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
