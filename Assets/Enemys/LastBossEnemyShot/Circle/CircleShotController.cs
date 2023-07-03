using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShotController : MonoBehaviour {
    public EffectController Collision;
    GameDirector gd;
    
    [SerializeField] GameObject BossEnemyShot;

    int level;
    float rotate;
    float limit;
    float delta;
    float speed = 5f;

    void Start () {
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        level = 6;
        rotate = 30;
        limit = Random.Range(1, 2.5f);
        delta = 0;
    }

    void Update() {
        delta += Time.deltaTime;
        if (delta > limit) {
            delta = 0;
            for (int i = -level; i < level + 1; i++) {
                //���ݒn���擾
                Vector3 p = transform.position;

                //��]�p�x���擾
                Quaternion rot = Quaternion.identity;
                rot.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, rotate * i);

                //���ݒn�Ɗp�x���Z�b�g
                Instantiate(BossEnemyShot, p, rot);
            }
            Destroy(gameObject);
        }

        //�ړ�
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.tag == "Player") {
            //�G�e�ɓ���������Score: -750, HP: -2.5
            gd.Score -= 1000;
            gd.HP -= 5;

            //SE
            SeManager.Instance.Play("se_explode11");

            //Effect
            Collision.transform.localScale = new Vector3(2, 2, 0);
            Instantiate(Collision, transform.localPosition, Quaternion.identity);
            
            Destroy(gameObject);
        }
    }
}
