using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    public GameObject EnemyPrefab;          //�G�̃v���n�u��ۑ�����ϐ�
    [SerializeField] private float Ran;
    [SerializeField] private float Span;    //�G���o�����o�i�b�j��ۑ�����ϐ�
    float Delta;                            //�o�ߎ��Ԍv�Z�p

    void Start() {
        Delta = 0;
    }

    void Update() {
        Delta += Time.deltaTime;
        if(Delta >= Span) {
            //�G�𐶐�����
            GameObject go = Instantiate(EnemyPrefab);
            float py = Random.Range(-Ran, Ran);
            go.transform.position = new Vector3(10, py, 0);

            //���Ԍo�߂�ۑ����Ă���ϐ���0�N���A����
            Delta = 0;

            //�G���o�����o�����X�ɒZ������
            Span -= (Span >= 0.5f) ? 0.01f : 0f;    //�X�p�����������Z������
        }
    }
}
