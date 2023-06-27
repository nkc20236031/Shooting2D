using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour {
    PlayerController pc;

    GameObject player;

    float limit;
    float delta;

    void Start() {
        player = GameObject.Find("Player");

        limit = 5f;
        delta = 0;

        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update() {
        transform.position = player.transform.position;

        //5秒間スピードUP
        delta += Time.deltaTime;
        if (delta > limit) {
            delta = 0;
            pc.Speed = 10;
            Destroy(gameObject);
        }
    }
}
