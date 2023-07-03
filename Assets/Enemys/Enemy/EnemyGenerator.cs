using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    GameDirector gd;
    GameObject go;

    [SerializeField] GameObject EnemyPre;           //�G�̃v���n�u��ۑ�����ϐ�
    [SerializeField] GameObject aEnemyPre;          //����a�G�̃v���n�u��ۑ�����ϐ�
    [SerializeField] GameObject BossEnemyPre;       //�{�X�̃v���n�u��ۑ�����ϐ�
    [SerializeField] GameObject LastBossEnemyPre;   //���X�{�X�̃v���n�u��ۑ�����ϐ�

    int random;
    float span = 1f;                                //�G���o���Ԋu�i�b�j��ۑ�����ϐ�
    float delta = 0;                                //�o�ߎ��Ԍv�Z�p
    bool Boss;
    bool LastBoss;

    void Start () {
        Boss = false;
        LastBoss = false;

        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    void Update() {
        if (LastBoss == false) {
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

            //�{�X�𐶐�����i�X�R�A��15000�ȏ�@�{�@1��̂݁j
            if (gd.Score > 15000 && Boss == false) {
                Boss = true;
                go = Instantiate(BossEnemyPre);
                go.transform.position = new Vector3(12, 0, 0);
            }

            //���X�{�X�̐���
            if (Boss == true && gd.Score > 75000 || gd.Summon) {
                LastBoss = true;
                gd.Summon = false;
                go = Instantiate(LastBossEnemyPre);
                go.transform.position = new Vector3(12, 0, 0);
            }
        }
    }
}
