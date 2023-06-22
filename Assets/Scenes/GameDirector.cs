using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    [SerializeField] GameObject bonus;
    [SerializeField] Image timeGauge;           //タイムゲージを表示するUI-Imageオブジェクトを保存
    [SerializeField] Text kyoriLabel;           //距離を表示するUI-Textオブジェクトを保存
    public static int kyori;                    //距離を保存する変数
    float lastTime;                             //残り時間を保存する変数
    float span;
    float delta;

    void Start() {
        Application.targetFrameRate = 60;       //フレームレート(60)
        kyori = 0;
        lastTime = 100f;                        //残り時間
        span = 10f;
        delta = 0;
    }

    void Update() {
        //残り時間を減らす処理
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 100f;

        //残り時間が０になったらタイトルシーンに移動
        if(lastTime < 0) {
            SceneManager.LoadScene("TitleScene");
        }

        //進んだ距離を表示
        if (kyori < 0) {
            kyori = 0;
        }
        kyori++;
        kyoriLabel.text = ($"Score: {kyori.ToString("D6")}");

        //ボーナス玉
        delta += Time.deltaTime;
        if (delta > span) {
            delta = 0;
            GameObject go = Instantiate(bonus);
            float py = Random.Range(-9f, 10f);
            go.transform.position = new Vector3(py, 7, 0);
        }
    }
}
