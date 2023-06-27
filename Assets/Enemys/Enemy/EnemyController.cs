using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public EffectController Explosion;
    GameDirector gd;
    
    Vector3 dir = Vector3.zero;                 //�ړ�����

    int attack;
    int random;
    float speed;                                //�ړ����x
    float rad;

    void Start() {
        attack = 0;
        speed = 5f;
        rad = Time.time;

        random = Random.Range(0, 10);
        if (random < 1) {
            Destroy(gameObject, 10f);
        } else {
            Destroy(gameObject, 5f);
        }

        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    void Update() {
        //�ړ�����������
        dir = Vector3.left;

        if (random < 3) {   //�㉺�ړ�
            dir.y = Mathf.Sin(rad + Time.time * speed);
        }

        //���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            //�G�ɓ���������-500���炷
            gd.Score -= 500;
            gd.HP -= 10;

            //�������ɃG�t�F�N�g���o��
            Explosion.transform.localScale = new Vector3(2f, 2f, 0);
            Instantiate(Explosion, transform.localPosition, Quaternion.identity);

            //�������̃I�u�W�F�N�g�Əd�Ȃ��������
            Destroy(gameObject);
        } else if (obj.tag == "MyShot") {
            attack++;
            Destroy(obj);
            if (attack == 3) {
                //�|������+200���₷
                gd.Score += 200;

                //�������ɃG�t�F�N�g���o��
                Explosion.transform.localScale = new Vector3(2f, 2f, 0);
                Instantiate(Explosion, transform.localPosition, Quaternion.identity);

                //�������̃I�u�W�F�N�g�Əd�Ȃ��������
                Destroy(gameObject);
            }
        }
    }
}
