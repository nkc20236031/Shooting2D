using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShotController : MonoBehaviour {
    public EffectController Col;
    GameDirector gd;

    float speed;
    float limit;
    float delta;
    bool check;

    void Start () {
        Destroy(gameObject, 10);

        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        speed = 5f;
        limit = 5;
        delta = 0;
        check = true;
    }

    void Update() {
        if (gd.Attack && check) {
            delta += Time.deltaTime;
            if (delta > limit) {
                delta = 0;
                check = false;
                transform.eulerAngles += new Vector3(0, 0, 180);
            }
        }

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
