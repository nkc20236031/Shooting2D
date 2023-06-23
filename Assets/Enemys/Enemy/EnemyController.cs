using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public EffectController Explosion;
    [SerializeField] GameObject EnemyShot;
    Vector3 dir = Vector3.zero;                 //�ړ�����
    int attack;
    int random;
    float span;
    float delta;
    float speed;                                //�ړ����x
    float rad;

    void Start() {
        attack = 0;
        random = Random.Range(0, 10);
        span = 2f;
        speed = 5f;
        rad = Time.time;
        if (random < 1) {
            Destroy(gameObject, 10f);
        } else {
            Destroy(gameObject, 5f);
        }
    }

    void Update() {
        //�ړ�����������
        dir = Vector3.left;

        if (random < 3) {   //�㉺�ړ�
            dir.y = Mathf.Sin(rad + Time.time * speed);
        } else {            //�U��
            delta += Time.deltaTime;
            if (delta > span) {
                delta = 0;
                Instantiate(EnemyShot, transform.position, transform.rotation);
            }
        }

        //���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            //�G�ɓ���������-1000km���炷
            GameDirector.kyori -= 500;
            GameDirector.hp -= 5;

            //�������ɃG�t�F�N�g���o��
            Explosion.transform.localScale = new Vector3(2f, 2f, 0);
            Instantiate(Explosion, transform.localPosition, Quaternion.identity);

            //�������̃I�u�W�F�N�g�Əd�Ȃ��������
            Destroy(gameObject);
        } else if (obj.tag == "MyShot") {
            attack++;
            Destroy(obj);
            if (attack == 3) {
                //�|������+200km���₷
                GameDirector.kyori += 200;

                //�������ɃG�t�F�N�g���o��
                Explosion.transform.localScale = new Vector3(2f, 2f, 0);
                Instantiate(Explosion, transform.localPosition, Quaternion.identity);

                //�������̃I�u�W�F�N�g�Əd�Ȃ��������
                Destroy(gameObject);
            }
        }
    }
}
