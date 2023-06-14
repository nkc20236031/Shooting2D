using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShotController : MonoBehaviour {
    [SerializeField] private float speed;

    void Start () {
        Destroy(gameObject, 4f);
    }

    void Update() {
        //ˆÚ“®
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
