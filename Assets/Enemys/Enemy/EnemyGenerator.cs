using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    GameDirector gd;
    GameObject go;

    [SerializeField] GameObject EnemyPre;           //敵のプレハブを保存する変数
    [SerializeField] GameObject aEnemyPre;          //強化a敵のプレハブを保存する変数
    [SerializeField] GameObject BossEnemyPre;       //ボスのプレハブを保存する変数
    [SerializeField] GameObject LastBossEnemyPre;   //ラスボスのプレハブを保存する変数

    int random;
    float span = 1f;                                //敵を出す間隔（秒）を保存する変数
    float delta = 0;                                //経過時間計算用
    bool Boss;
    bool LastBoss;

    void Start () {
        Boss = false;
        LastBoss = false;

        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    void Update() {
        if (LastBoss == false) {
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

            //ボスを生成する（スコアが15000以上　＋　1回のみ）
            if (gd.Score > 15000 && Boss == false) {
                Boss = true;
                go = Instantiate(BossEnemyPre);
                go.transform.position = new Vector3(12, 0, 0);
            }

            //ラスボスの生成
            if (Boss == true && gd.Score > 75000 || gd.Summon) {
                LastBoss = true;
                gd.Summon = false;
                go = Instantiate(LastBossEnemyPre);
                go.transform.position = new Vector3(12, 0, 0);
            }
        }
    }
}
