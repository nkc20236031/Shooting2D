using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShotController : MonoBehaviour {
    public EffectController Col;
    float speed;

    void Start () {
        speed = 10f;

        Destroy(gameObject, 2f);
    }

    void Update() {
        //ˆÚ“®
        transform.position += transform.up * speed * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Enemy") {
            Instantiate(Col, transform.localPosition, Quaternion.identity);
        }
    }
}
