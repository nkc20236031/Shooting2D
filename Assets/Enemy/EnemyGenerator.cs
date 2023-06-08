using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    public GameObject EnemyPrefab;          //敵のプレハブを保存する変数
    [SerializeField] private float Ran;
    [SerializeField] private float Span;    //敵を出す感覚（秒）を保存する変数
    float Delta;                            //経過時間計算用

    void Start() {
        Delta = 0;
    }

    void Update() {
        Delta += Time.deltaTime;
        if(Delta >= Span) {
            //敵を生成する
            GameObject go = Instantiate(EnemyPrefab);
            float py = Random.Range(-Ran, Ran);
            go.transform.position = new Vector3(10, py, 0);

            //時間経過を保存している変数を0クリアする
            Delta = 0;

            //敵を出す感覚を徐々に短くする
            Span -= (Span >= 0.5f) ? 0.01f : 0f;    //スパンを少しずつ短くする
        }
    }
}
