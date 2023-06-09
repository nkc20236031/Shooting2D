using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitEffect : MonoBehaviour {
    GameObject player;

    float limit;        //残り時間を保存する変数
    float delta;

    void Start() {
        player = GameObject.Find("Player");

        limit = 3f;
        delta = 0;
    }

void Update() {
    transform.position = player.transform.position;

    //limit秒後に消滅
    delta += Time.deltaTime;
    if (delta > limit) {
        delta = 0;
        Destroy(gameObject);
    }
}
}
