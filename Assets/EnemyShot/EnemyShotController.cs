using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour {
    GameObject player;
    Vector3 dir = Vector3.zero;     //�ړ�����
    float speed;

    void Start() {
        speed = 10f;

        Destroy(gameObject, 4f);

        //�v���C���[�̂ق��Ɍ�����
        player = GameObject.Find("Player");
        dir = player.transform.position - transform.position;
    }

    void Update() {
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            //�G�e�ɓ���������-500km
            GameDirector.kyori -= 500;
            Destroy(gameObject);
        }
    }
}
