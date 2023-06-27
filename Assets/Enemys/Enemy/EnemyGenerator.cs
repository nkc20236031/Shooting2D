using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    GameDirector gd;
    GameObject go;

    [SerializeField] GameObject EnemyPre;       //�G�̃v���n�u��ۑ�����ϐ�
    [SerializeField] GameObject aEnemyPre;
    [SerializeField] GameObject BossEnemyPre;

    int random;
    float span = 1f;                            //�G���o���Ԋu�i�b�j��ۑ�����ϐ�
    float delta = 0;                            //�o�ߎ��Ԍv�Z�p
    bool boss;

    void Start () {
        boss = false;

        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    void Update() {
        //�o�ߎ��Ԃ����Z
        delta += Time.deltaTime;
        if (delta > span) {
            //���Ԍo�߂�ۑ����Ă���ϐ����O�N���A����
            delta = 0;

            //�G�𐶐�����
            random = Random.Range(0, 10);
            if (random < 1) {
                go = Instantiate(aEnemyPre);
            } else {
                go = Instantiate(EnemyPre);
            }
            float py = Random.Range(-4.25f, 4.25f);
            go.transform.position = new Vector3(10, py, 0);

            //�G���o���Ԋu�����X�ɒZ������
            span -= (span > 0.5f)? 0.01f : 0f;
        }

        if (gd.Score > 15000 && boss == false) {
            boss = true;
            go = Instantiate(BossEnemyPre);
            go.transform.position = new Vector3(12, 0, 0);
        }
    }
}
