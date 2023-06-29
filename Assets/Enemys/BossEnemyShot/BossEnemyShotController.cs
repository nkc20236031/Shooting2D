using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShotController : MonoBehaviour {
    public EffectController Col;
    GameDirector gd;
    
    float speed;            //“G’e‚Ì‘¬“x

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
            //“G’e‚É“–‚½‚Á‚½‚çScore: -750, HP: -2.5
            gd.Score -= 750;
            gd.HP -= 2.5f;

            //SE
            SeManager.Instance.Play("se_explode11");

            //Effect
            Instantiate(Col, transform.localPosition, Quaternion.identity);
            
            Destroy(gameObject);
        }
    }
}
