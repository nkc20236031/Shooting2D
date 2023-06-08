using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] private float speed;   //�ړ����x
    Vector3 dir = Vector3.zero;             //�ړ�����

    void Start() {
        //����4�b
        Destroy(gameObject, 4f);
    }

    void Update() {
        //�ړ�����������
        dir = Vector3.left;
        //���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        //�������Ԃ�10�b���炷
        GameDirector.LastTime -= 10f;

        //�����̃I�u�W�F�N�g�ɏd�Ȃ��������
        Destroy(gameObject);
    }
}
