using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    [SerializeField] GameObject bonus;      //ボーナスアイテムオブジェクトを保存
    [SerializeField] Image TimeGauge;       //タイムゲージを表示するUI-Imageオブジェクトを保存
    [SerializeField] Image HpBar;           //体力ゲージを表示するUI-Imageオブジェクトを保存
    [SerializeField] Text ScoreLabel;       //スコアを表示するUI-Textオブジェクトを保存

    int score;                              //スコアを保存する変数
    float hp;                               //残りの体力を保存する変数
    float span;                             //弾の召喚時間間隔を保存する変数
    float delta;
    float lasttime;                         //残り時間を保存する変数
    float limit;
    float del;
    bool esc;
    bool LastBossAttack;

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

    public bool Attack {
        get { return LastBossAttack; }
        set { LastBossAttack = value; }
    }

    void Start() {
        Application.targetFrameRate = 60;   //フレームレート(60)

        span = 10f;
        delta = 0;
        lasttime = 480;
        hp = 100;
        score = 0;
        limit = 3;
        del = 0;
        esc = false;

        //BGM
        BgmManager.Instance.Play("bgm_maoudamashii_8bit11");
    }

    void Update() {
        //HP
        HpBar.fillAmount = hp / 100;

        //残り時間
        lasttime -= Time.deltaTime;
        TimeGauge.fillAmount = lasttime / 480;

        //残り時間または体力が０になったらタイトルシーンに移動
        if (hp == 0 || TimeGauge.fillAmount <= 0) {
            BgmManager.Instance.Stop();
            ScoreDirector.GameScore = Score;
            SceneManager.LoadScene("TitleScene");
        }

        //スコアを表示
        if (score < 0) {
            score = 0;
        }
        score += (score < 999999)? 1:0;
        ScoreLabel.text = ($"Score: {score.ToString("D6")}");

        //ボーナスアイテム
        delta += Time.deltaTime;
        if (delta > span) {
            delta = 0;
            GameObject go = Instantiate(bonus);
            float py = Random.Range(-8.5f, 9.5f);
            go.transform.position = new Vector3(py, 7, 0);
        }

        //エスケープキーを押した判定
        if (Input.GetKeyDown(KeyCode.Escape)) {
            esc = true;
        } else if (Input.GetKeyUp(KeyCode.Escape)) {
            esc = false;
            del = 0;
        }

        //ゲーム終了
        if (esc) {
            del += Time.deltaTime;
            if (del > limit) {
                del = 0;
                Application.Quit();
            }
        }
    }
}

public static class ScoreDirector {
    public static int GameScore { get; set; }
}
