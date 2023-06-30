using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBossEnemyController : MonoBehaviour {
    public EffectController Explosion;
    GameDirector gd;

    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject BossEnemyShot;

    Vector3 dir = Vector3.zero;

    int LastBossHP;
    float rad;
    float speed;
    float span1;
    float span2;
    float delta1;
    float delta2;
    float random;
    float limit1;
    float limit2;
    float del1;
    float del2;
    bool check1;

    enum Pattern { StartPat, WayPat, EndPat }
    Pattern nowLBState = Pattern.StartPat;

    enum AttackPat { AttackPat1,  AttackPat2, AttackPat3 }
    AttackPat nowLBAttack = AttackPat.AttackPat1;

    void Start () {
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        LastBossHP = 1200;
        rad = Time.time;
        speed = 7.5f;
        span1 = 2.5f;
        span2 = 2;
        delta1 = 0;
        delta2 = 0;
        limit1 = 30;
        limit2 = 3;
        del1 = 0;
        del2 = 0;
        random = Random.Range(-4.25f, 4.25f);
        check1 = true;
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
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(5, 0, 0), 5 * Time.deltaTime);

        if (transform.position.x == 5) {
            nowLBState = Pattern.WayPat;
        } else if (LastBossHP <= 0) {
            nowLBState = Pattern.EndPat;
        }
    }

    void Way() {
        switch (nowLBAttack) {
            case AttackPat.AttackPat1:
                Barrage();
                break;
            case AttackPat.AttackPat2:
                Charge();
                break;
            case AttackPat.AttackPat3:
                Summon();
                break;
        }
        alWay();

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

    private void alWay() {
        delta1 += Time.deltaTime;
        if (delta1 > span1) {
            delta1 = 0;

            Enemy.transform.position = transform.position + new Vector3(10, random, 0);
            Instantiate(Enemy);

            random = Random.Range(-4.25f, 4.25f);
        }
    }

    void Barrage() {
        //弾を生成する
        delta2 += Time.deltaTime;
        if (delta2 > span2) {
            delta2 = 0f;

            //大弾
            BossEnemyShot.transform.localScale = new Vector3(5, 5, 0);
            BossEnemyShot.transform.position = new Vector3(5, random, 0);
            Instantiate(BossEnemyShot);

            random = Random.Range(-4.25f, 4.25f);
        }

        //30秒後攻撃パターン切り替え
        del1 += Time.deltaTime;
        if (del1 > limit1) {
            del1 = 0;
            nowLBAttack = AttackPat.AttackPat2;
        }
    }

    void Charge() {
        if (check1) {
            delta2 += Time.deltaTime;
            if (delta2 < span2) {
                dir.y = Mathf.Sin(rad + Time.time * speed / 2);
            } else {
                delta2 = 0;
                check1 = false;
            }
            transform.position += dir.normalized * speed * Time.deltaTime;
        } else {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(-5, 0, 0), speed * Time.deltaTime);
            if (transform.position.x < -10) {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(5, 0, 0), speed * Time.deltaTime);
                if (transform.position.x >= 5) {
                    check1 = true;
                }
            }
        }

        //30秒後攻撃パターン切り替え
        del1 += Time.deltaTime;
        if (del1 > limit1) {
            del1 = 0;
            nowLBAttack = AttackPat.AttackPat3;
        }
    }

    void Summon() {

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
