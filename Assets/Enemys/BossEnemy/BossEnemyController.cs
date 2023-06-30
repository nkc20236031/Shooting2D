using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : MonoBehaviour {
    public EffectController Explosion;
    GameDirector gd;

    [SerializeField] GameObject BossEnemyShot;
    GameObject player;
    Vector3 dir = Vector3.zero;

    int BossHP;                             //�{�X�̗̑�
    float speed;                            //�ړ����x
    float rad;
    float span;                             //�{�X�e�̏������Ԃ̊Ԋu
    float delta;
    
    void Start() {
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        player = GameObject.Find("Player");
        
        BossHP = 0;
        speed = 5f;
        rad = Time.time;
        span = 0.5f;
        delta = 0;

        Destroy(gameObject, 300f);

    }

    void Update() {
        //�ړ�
        dir.y = Mathf.Sin(rad + Time.time * speed);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(7, dir.y, 0), speed * Time.deltaTime);

        //�ړ�����
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        //�e�𐶐�����
        delta += Time.deltaTime;
        if (delta > span) {
            delta = 0f;
            //���ݒn���擾
            Vector3 p = transform.position;

            //��]�p�x���擾
            Quaternion rot = Quaternion.identity;
            rot.eulerAngles = transform.rotation.eulerAngles;

            //���ݒn�Ɗp�x���Z�b�g
            Instantiate(BossEnemyShot, p, rot);

            span = Random.Range(0.5f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {              //�v���C���[�Ɠ�����
            //�v���C���[��Score: -1500, HP: -25
            gd.Score -= 1500;
            gd.HP -= 25;
        } else if (obj.tag == "MyShot") {       //�v���C���[�̒e�Ɠ�����
            BossHP++;
            Destroy(obj);
            if (BossHP == 300) {
                //Score: +5000
                gd.Score += 5000;
                
                //SE
                SeManager.Instance.Play("se_bomb2-1");

                //�G�t�F�N�g
                Explosion.transform.localScale = new Vector3(3f, 3f, 0);
                Instantiate(Explosion, transform.localPosition, Quaternion.identity);
                
                Destroy(gameObject);
            }
        }
    }
}
