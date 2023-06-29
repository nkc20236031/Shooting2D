using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBossEnemyController : MonoBehaviour {
    public EffectController Explosion;
    GameDirector gd;
    Vector3 dir = Vector3.zero;
    int LastBossHP;
    float Speed;

    enum Pattern { StartPat, WayPat, EndPat }
    Pattern nowLBState = Pattern.StartPat;

    void Start () {
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        LastBossHP = 750;
        Speed = 5f;
    }

    void Update () {
        switch (nowLBState) {
            case Pattern.StartPat:
                Spawn();
                break;
            case Pattern.WayPat:
                Way();
                break;
            case Pattern.EndPat:
                End();
                break;
        }
    }

    void Spawn() {
        bool Check = false;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(5, 0, 0), Speed * Time.deltaTime);

        if (Check) {
            nowLBState = Pattern.WayPat;
        } else if (LastBossHP <= 0) {
            nowLBState = Pattern.EndPat;
        }
    }

    void Way() {
        if (LastBossHP <= 0) {
            nowLBState = Pattern.EndPat;
        }
    }

    void End() {
        //Score: +15000
        gd.Score += 15000;

        //SE
        SeManager.Instance.Play("se_bomb2-1");

        //Effect
        Explosion.transform.localScale = new Vector3(5f, 5f, 0);
        Instantiate(Explosion, transform.localPosition, Quaternion.identity);

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {              //プレイヤーと当たる
            //プレイヤーのScore: -1750, HP: -37.5
            gd.Score -= 1750;
            gd.HP -= 37.5f;
        } else if (obj.tag == "MyShot") {       //プレイヤーの弾と当たる
            LastBossHP--;
            Destroy(obj);
        }
    }
}
