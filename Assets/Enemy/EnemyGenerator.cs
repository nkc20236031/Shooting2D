using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    [SerializeField] GameObject enemyPre;   //敵のプレハブを保存する変数
    float span;                             //敵を出す間隔（秒）を保存する変数
    float delta;                            //経過時間計算用

    void Start() {
        span  = 1f;
        delta = 0;
    }

    void Update() {
        //経過時間を加算
        delta += Time.deltaTime;
        if (delta > span) {
            //時間経過を保存している変数を０クリアする
            delta = 0;

            //敵を生成する
            GameObject go = Instantiate(enemyPre);
            float py = Random.Range(-6f, 7f);
            go.transform.position = new Vector3(10, py, 0);

            //敵を出す間隔を徐々に短くする
            span -= (span > 0.5f)? 0.01f : 0f;
        }
    }
}










