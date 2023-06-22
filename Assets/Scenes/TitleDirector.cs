using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {
    [SerializeField] Text Score;    //スコアを表示するするUI-Textオブジェクトを保存

    void Start() {
        //スコアの表示
        string ScoreRec = GameDirector.kyori.ToString("D6");
        Score.text = (
            $"Score\n" +
            $"{ScoreRec}"
        );
    }

    void Update() {
        //z or leftctrl or mouse0
        if (Input.GetButtonDown("Start")) {
            SceneManager.LoadScene("GameScene");
        }
    }
}
