using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour {
    Vector3 dir = Vector3.zero;
    int random;
    float speed;

    void Start() {
        //�}�e���A���J���[�̕ύX
        random = Random.Range(0, 3);
        Material mat = GetComponent<Renderer>().material;
        switch (random) {
            case 0:
                mat.color = Color.red;      //�ԋ�
                break;
            case 1:
                mat.color = Color.green;    //�΋�
                break;
            case 2:
                mat.color = Color.blue;     //��
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

    //�V���b�gUP
    void Red() {
        MyShotGenerator.level += (MyShotGenerator.level == 12)? 0:1;
    }

    //�X�s�[�hUP
    void Green() {
        PlayerController.speed += (PlayerController.speed < 20)? 2:0;
    }

    //���\�_�E��
    void Blue() {
        MyShotGenerator.level = 0;
        PlayerController.speed = 10;
    }
}
