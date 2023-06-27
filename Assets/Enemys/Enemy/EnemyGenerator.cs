using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    GameDirector gd;
    GameObject go;

    [SerializeField] GameObject EnemyPre;       //敵のプレハブを保存する変数
    [SerializeField] GameObject aEnemyPre;
    [SerializeField] GameObject BossEnemyPre;

    int random;
    float span = 1f;                            //敵を出す間隔（秒）を保存する変数
    float delta = 0;                            //経過時間計算用
    bool boss;

    void Start () {
        boss = false;

        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    void Update() {
        //経過時間を加算
        delta += Time.deltaTime;
        if (delta > span) {
            //時間経過を保存している変数を０クリアする
            delta = 0;

            //敵を生成する
            random = Random.Range(0, 10);
            if (random < 1) {
                go = Instantiate(aEnemyPre);
            } else {
                go = Instantiate(EnemyPre);
            }
            float py = Random.Range(-4.25f, 4.25f);
            go.transform.position = new Vector3(10, py, 0);

            //敵を出す間隔を徐々に短くする
            span -= (span > 0.5f)? 0.01f : 0f;
        }

        if (gd.Score > 15000 && boss == false) {
            boss = true;
            go = Instantiate(BossEnemyPre);
            go.transform.position = new Vector3(12, 0, 0);
        }
    }
}
