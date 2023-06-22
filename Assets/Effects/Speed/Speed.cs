using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour {
    GameObject player;
    float limit;
    float delta;

    void Start() {
        player = GameObject.Find("Player");

        limit = 5f;
        delta = 0;
    }

    void Update() {
        transform.position = player.transform.position;

        //5秒間スピードUP
        delta += Time.deltaTime;
        if (delta > limit) {
            delta = 0;
            PlayerController.speed = 10;
            Destroy(gameObject);
        }
    }
}
