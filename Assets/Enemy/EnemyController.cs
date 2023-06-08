using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] private float speed;   //移動速度
    Vector3 dir = Vector3.zero;             //移動方向

    void Start() {
        //寿命4秒
        Destroy(gameObject, 4f);
    }

    void Update() {
        //移動方向を決定
        dir = Vector3.left;
        //現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        //制限時間を10秒減らす
        GameDirector.LastTime -= 10f;

        //何かのオブジェクトに重なったら消去
        Destroy(gameObject);
    }
}
