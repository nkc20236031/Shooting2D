using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class aEnemyController : MonoBehaviour {
    public EffectController Explosion;
    public EffectController Collision;
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
                    GameDirector.kyori -= 1500;

                    Destroy(gameObject);
                    break;
                case "MyShot":
                    attack++;
                    Destroy(obj);
                    //5��U��������������
                    if (attack == 5) {
                        //�������ɃG�t�F�N�g���o��
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
