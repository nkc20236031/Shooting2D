using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour {
    [SerializeField] private float speed;
    GameObject player;
    Vector3 dir = Vector3.zero; //�ړ�����

    void Start() {
        Destroy(gameObject, 4);

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
            GameDirector.kyori -= 500;
            Destroy(gameObject);
        }
    }
}
