using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShotController : MonoBehaviour {
    public EffectController Col;
    GameDirector gd;
    
    float speed;

    void Start () {
        speed = 10f;

        Destroy(gameObject, 2f);

        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    void Update() {
        //ˆÚ“®
        transform.position += transform.up * speed * Time.deltaTime;
    }
    
    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            //“G’e‚É“–‚½‚Á‚½‚ç-750
            gd.Score -= 750;
            gd.HP -= 2.5f;

            Instantiate(Col, transform.localPosition, Quaternion.identity);
            
            Destroy(gameObject);
        }
    }
}
