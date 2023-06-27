using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    [SerializeField] GameObject bonus;
    [SerializeField] Image HpBar;           //体力ゲージを表示するUI-Imageオブジェクトを保存
    [SerializeField] Text ScoreLabel;       //スコアを表示するUI-Textオブジェクトを保存

    int score;                              //スコアを保存する変数
    float hp;                               //残りの体力を保存する変数
    float span;
    float delta;

    public int Score {
        get { return score; }
        set {
            score = value;
            score = Mathf.Clamp(score, 0, 999999);
        }
    }

    public float HP {
        get { return hp; }
        set {
            hp = value;
            hp = Mathf.Clamp(hp, 0, 100);
        }
    }

    void Start() {
        Application.targetFrameRate = 60;   //フレームレート(60)
        span = 10f;
        delta = 0;

        hp = 100;
        score = 0;
    }

    void Update() {
        HpBar.fillAmount = hp / 100;
        
        //残り時間が０になったらタイトルシーンに移動
        if (hp == 0) {
            ScoreDirector.GameScore = Score;
            SceneManager.LoadScene("TitleScene");
        }

        //進んだ距離を表示
        if (score < 0) {
            score = 0;
        }
        score++;
        ScoreLabel.text = ($"Score: {score.ToString("D6")}");

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

public static class ScoreDirector {
    public static int GameScore { get; set; }
}
