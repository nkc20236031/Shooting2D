using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {
    [SerializeField] Text Score;    //スコアを表示するするUI-Textオブジェクトを保存
    bool esc;
    float limit;
    float delta;

    void Start() {
        esc = false;
        limit = 1;
        delta = 0;

        //スコアの表示
        string ScoreRec = ScoreDirector.GameScore.ToString("D6");
        Score.text = ScoreRec;
    }

    void Update() {
        //z or leftctrl or mouse0
        if (Input.GetButtonDown("Start")) {
            SceneManager.LoadScene("GameScene");
        }

        //エスケープキーを押した判定
        if (Input.GetKeyDown(KeyCode.Escape)) {
            esc = true;
        } else if (Input.GetKeyUp(KeyCode.Escape)) {
            esc = false;
            delta = 0;
        }

        //ゲーム終了
        if (esc) {
            delta += Time.deltaTime;
            if (delta > limit) {
                delta = 0;
                Application.Quit();
            }
        }
    }
}
