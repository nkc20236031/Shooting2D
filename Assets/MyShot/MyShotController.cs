using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShotController : MonoBehaviour {
    public EffectController Collision;

    float speed;

    void Start () {
        speed = 10f;

        Destroy(gameObject, 2f);
    }

    void Update() {
        //�ړ�
        transform.position += transform.up * speed * Time.deltaTime;
    }
    
    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Enemy") {
            Instantiate(Collision, transform.localPosition, Quaternion.identity);
        }
    }
}
