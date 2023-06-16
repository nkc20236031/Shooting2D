using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShotController : MonoBehaviour {
    float speed;

    void Start () {
        speed = 10f;

        Destroy(gameObject, 2f);
    }

    void Update() {
        //ˆÚ“®
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
