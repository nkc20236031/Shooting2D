using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    [SerializeField] GameObject bonus;
    [SerializeField] Image HpBar;           //タイムゲージを表示するUI-Imageオブジェクトを保存
    [SerializeField] Text kyoriLabel;       //距離を表示するUI-Textオブジェクトを保存
    public static int kyori;                //距離を保存する変数
    public static float hp;                               //残り時間を保存する変数
    float span;
    float delta;

    void Start() {
        Application.targetFrameRate = 60;   //フレームレート(60)
        kyori = 0;
        hp = 100f;                          //体力
        span = 10f;
        delta = 0;
    }

    void Update() {
        HpBar.fillAmount = hp / 100;
        
        //残り時間が０になったらタイトルシーンに移動
        if(hp < 0) {
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
            float py = Random.Range(-8.5f, 9.5f);
            go.transform.position = new Vector3(py, 7, 0);
        }
    }
}
