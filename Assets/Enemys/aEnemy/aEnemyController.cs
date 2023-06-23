using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aEnemyController : MonoBehaviour {
    public EffectController Explosion;
    [SerializeField] GameObject EnemyShot;
    GameObject player;
    int attack;

    void Start() {
        player = GameObject.Find("Player");
        attack = 0;

        Destroy(gameObject, 10f);
    }

    void Update() {
        //�Ǐ]
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 4f * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player" || obj.tag == "MyShot") {
            switch (obj.tag) {
                case "Player":
                    //�G�ɓ���������-1000km���炷
                    GameDirector.kyori -= 1000;
                    GameDirector.hp -= 20;

                    //�������ɃG�t�F�N�g���o��
                    Explosion.transform.localScale = new Vector3(2f, 2f, 0);
                    Instantiate(Explosion, transform.localPosition, Quaternion.identity);

                    Destroy(gameObject);
                    break;
                case "MyShot":
                    attack++;
                    Destroy(obj);
                    //5��U��������������
                    if (attack == 5) {
                        //�������ɃG�t�F�N�g���o��
                        Explosion.transform.localScale = new Vector3(2.5f, 2.5f, 0);
                        Instantiate(Explosion, transform.localPosition, Quaternion.identity);

                        //�������̃I�u�W�F�N�g�Əd�Ȃ��������
                        Destroy(gameObject);

                        //�|������+200km���₷
                        GameDirector.kyori += 500;
                    }
                    break;
            }
        }
    }
}
