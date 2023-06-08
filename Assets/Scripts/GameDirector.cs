using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    public Text KyoriLabel;         //距離を表示するUI-Textオブジェクトを保存する変数
    public Image TimeGauge;         //タイムゲージを表示するUI
    public static float LastTime;   //残り時間を保存する変数
    int Kyori;                      //距離を保存する変数

    void Start() {
        Application.targetFrameRate = 60;
        Kyori = 0;
        LastTime = 100f;    //残り時間100秒
    }

    void Update() {
        //残り時間を減らす処理
        LastTime -= Time.deltaTime;
        TimeGauge.fillAmount = LastTime / 100f;

        //残り時間が0になったら
        if (LastTime < 0) {
            SceneManager.LoadScene("TitleScene");
        }

        //進んだ距離を表示
        Kyori++;
        KyoriLabel.text = ($"{Kyori.ToString("D6")}km");
    }
}
