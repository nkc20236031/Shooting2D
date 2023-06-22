using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    [SerializeField] GameObject aEnemyPre;
    [SerializeField] GameObject EnemyPre;       //�G�̃v���n�u��ۑ�����ϐ�
    GameObject go;
    float span = 2;                             //�G���o���Ԋu�i�b�j��ۑ�����ϐ�
    float delta = 0;                            //�o�ߎ��Ԍv�Z�p
    int random;

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
            span -= (span > 0.25f)? 0.01f : 0f;
        }
    }
}
