using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    [SerializeField] GameObject aEnemyPre;
    [SerializeField] GameObject EnemyPre;       //敵のプレハブを保存する変数
    GameObject go;
    float span = 2;                             //敵を出す間隔（秒）を保存する変数
    float delta = 0;                            //経過時間計算用
    int random;

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
            span -= (span > 0.25f)? 0.01f : 0f;
        }
    }
}
