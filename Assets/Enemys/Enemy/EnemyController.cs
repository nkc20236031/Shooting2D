using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public EffectController Explosion;
    GameDirector gd;
    
    Vector3 dir = Vector3.zero;                 //�ړ�����

    int enemyHp;                                //�G�l�~�[�̗̑�
    int random;                                 //�G�l�~�[�̎��
    float speed;                                //�ړ����x
    float rad;

    void Start() {
        enemyHp = 0;
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
            //�G�ɓ���������Score: -500, HP: -10���炷
            gd.Score -= 500;
            gd.HP -= 10;

            //SE
            SeManager.Instance.Play("se_baaan1");

            //�������ɃG�t�F�N�g���o��
            Explosion.transform.localScale = new Vector3(2f, 2f, 0);
            Instantiate(Explosion, transform.localPosition, Quaternion.identity);

            //�������̃I�u�W�F�N�g�Əd�Ȃ��������
            Destroy(gameObject);
        } else if (obj.tag == "MyShot") {
            enemyHp++;
            Destroy(obj);
            if (enemyHp == 3) {
                //�|������Score: +200���₷
                gd.Score += 200;

                //SE
                SeManager.Instance.Play("se_baaan1");
                
                //�������ɃG�t�F�N�g���o��
                Explosion.transform.localScale = new Vector3(2f, 2f, 0);
                Instantiate(Explosion, transform.localPosition, Quaternion.identity);

                //�������̃I�u�W�F�N�g�Əd�Ȃ��������
                Destroy(gameObject);
            }
        }
    }
}
