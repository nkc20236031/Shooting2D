using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour {
    PlayerController pc;

    GameObject player;

    float limit;        //残り時間を保存する変数
    float delta;

    void Start() {
        player = GameObject.Find("Player");

        limit = 5f;
        delta = 0;

        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update() {
        transform.position = player.transform.position;

        //5秒間移動速度1.5倍 + 弾速度2倍
        delta += Time.deltaTime;
        if (delta > limit) {
            delta = 0;
            pc.Speed = 10;
            pc.MyShotSpan = 0.25f;
            pc.MyShotSpeed = 10;
            Destroy(gameObject);
        }
    }
}
