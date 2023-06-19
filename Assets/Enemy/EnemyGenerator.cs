using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    [SerializeField] GameObject enemyPre;   //�G�̃v���n�u��ۑ�����ϐ�
    float span = 1;                             //�G���o���Ԋu�i�b�j��ۑ�����ϐ�
    float delta = 0;                            //�o�ߎ��Ԍv�Z�p

    void Update() {
        //�o�ߎ��Ԃ����Z
        delta += Time.deltaTime;
        if (delta > span) {
            //���Ԍo�߂�ۑ����Ă���ϐ����O�N���A����
            delta = 0;

            //�G�𐶐�����
            GameObject go = Instantiate(enemyPre);
            float py = Random.Range(-6f, 7f);
            go.transform.position = new Vector3(10, py, 0);

            //�G���o���Ԋu�����X�ɒZ������
            span -= (span > 0.5f)? 0.01f : 0f;
        }
    }
}
