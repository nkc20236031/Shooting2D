using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastBossEnemyController : MonoBehaviour {
    public EffectController Explosion;
    GameDirector gd;

    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject bEnemy;
    [SerializeField] GameObject CircleShot;

    int LastBossHP;
    int cnt;
    float speed;
    float span1;
    float span2;
    float span3;
    float delta1;
    float delta2;
    float delta3;
    float random;
    float limit;
    float del;
    bool check;

    enum Pattern { StartPat, WayPat, EndPat }
    Pattern nowLBState = Pattern.StartPat;

    enum AttackPat { AttackPat1,  AttackPat2, AttackPat3 }
    AttackPat nowLBAttack = AttackPat.AttackPat1;

    void Start () {
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        LastBossHP = 1500;
        cnt = 0;
        speed = 7.5f;
        span1 = 2.5f;
        span2 = 5;
        span3 = 0.5f;
        delta1 = 0;
        delta2 = 0;
        delta3 = 0;
        limit = 30;
        del = 0;
        random = Random.Range(-4.25f, 4.25f);
        check = true;
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

        gd.Attack = true;

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
        gd.Attack = false;

        //Score: +15000
        gd.Score += 15000;

        //SE
        SeManager.Instance.Play("se_bomb2-1");

        //Effect
        Explosion.transform.localScale = new Vector3(5f, 5f, 0);
        Instantiate(Explosion, transform.localPosition, Quaternion.identity);

        Destroy(gameObject);

        BgmManager.Instance.StopImmediately();
        ScoreDirector.GameScore = gd.Score;
        SceneManager.LoadScene("TitleScene");
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
            delta2 = 0;

            //大弾
            CircleShot.transform.position = new Vector3(5, random, 0);
            CircleShot.transform.eulerAngles = new Vector3(0, 0, 90);
            CircleShot.transform.localScale = new Vector3(5, 5, 0);
            Instantiate(CircleShot);

            random = Random.Range(-4.25f, 4.25f);
        }

        //30秒後攻撃パターン切り替え
        del += Time.deltaTime;
        if (del > limit) {
            del = 0;
            nowLBAttack = AttackPat.AttackPat2;
        }
    }

    void Charge() {
        delta2 += Time.deltaTime;
        if (delta2 < span2) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(5, 0, 0), speed * Time.deltaTime);
            check = true;
        } else {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-12, 0, 0), speed * Time.deltaTime);

            delta3 += Time.deltaTime;
            if (delta3 > span3) {
                delta3 = 0;

                random = Random.Range(0, 360);
                CircleShot.transform.position = transform.position;
                CircleShot.transform.eulerAngles = new Vector3(0, 0, random);
                CircleShot.transform.localScale = new Vector3(5, 5, 0);
                Instantiate(CircleShot);
            }

            if (check) {
                cnt++;
                check = false;
            }

            if (transform.position.x <= -12) {
                delta2 = 0;
            }
        }

        //攻撃パターン切り替え
        if (cnt == 5) {
            cnt = 0;
            transform.position = new Vector3(5, 0, 0);
            nowLBAttack = AttackPat.AttackPat3;
        }
    }

    void Summon() {
        delta2 += Time.deltaTime;
        if (delta2 > span2 - 3) {
            delta2 = 0;
            random = Random.Range(0, 7);
            for (float i = 0; i < 7; i++) {
                if (i != random) {
                    bEnemy.transform.position = new Vector3(10, (i * 1.5f) - 4.5f, 0);
                    Instantiate(bEnemy);
                } else {
                    Enemy.transform.position = new Vector3(10, (i * 1.5f) - 4.5f, 0);
                    Instantiate(Enemy);
                }
            }
        }

        //30秒後攻撃パターン切り替え
        del += Time.deltaTime;
        if (del > limit) {
            del = 0;
            nowLBAttack = AttackPat.AttackPat1;
        }
    }

    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.tag == "Player") {              //プレイヤーと当たる
            //プレイヤーのScore: -1750, HP: -37.5
            gd.Score -= 1750;
            gd.HP -= 37.5f;
        } else if (obj.tag == "MyShot") {       //プレイヤーの弾と当たる
            LastBossHP--;
            Destroy(obj.gameObject);
        }
    }
}
