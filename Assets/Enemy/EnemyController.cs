using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public ExplosionController Explosion;
    [SerializeField] GameObject EnemyShot;
    Vector3 dir = Vector3.zero;                 //�ړ�����
    int random;
    float span;
    float delta;
    float speed;                                //�ړ����x
    float rad;

    void Start() {
        Destroy(gameObject, 5f);

        random = Random.Range(0, 10);
        span = 2f;
        speed = 5f;
        rad = Time.time;
    }

    void Update() {
        //�ړ�����������
        dir = Vector3.left;

        //�㉺�^��
        if (random < 3) {
            dir.y = Mathf.Sin(rad + Time.time * speed);
        }

        //���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;

        //�G�e
        delta += Time.deltaTime;
        if (delta > span) {
            delta = 0;
            Instantiate(EnemyShot, transform.position, transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player" || obj.tag == "MyShot") {
            switch (obj.tag) {
                case "Player":
                    //�G�ɓ���������-1000km���炷
                    GameDirector.kyori -= 1000;
                    break;
                case "MyShot":
                    //�|������+200km���₷
                    GameDirector.kyori += 200;
                    Destroy(obj);
                    break;
            }

            //�������ɃG�t�F�N�g���o��
            Instantiate(Explosion, transform.localPosition, Quaternion.identity);

            //�������̃I�u�W�F�N�g�Əd�Ȃ��������
            Destroy(gameObject);
        }
    }
}
