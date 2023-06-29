using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitEffect : MonoBehaviour {
    GameObject player;

    float limit;        //�c�莞�Ԃ�ۑ�����ϐ�
    float delta;

    void Start() {
        player = GameObject.Find("Player");

        limit = 3f;
        delta = 0;
    }

void Update() {
    transform.position = player.transform.position;

    //limit�b��ɏ���
    delta += Time.deltaTime;
    if (delta > limit) {
        delta = 0;
        Destroy(gameObject);
    }
}
}
