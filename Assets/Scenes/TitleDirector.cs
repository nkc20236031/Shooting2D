using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {
    [SerializeField] Text Score;    //�X�R�A��\�����邷��UI-Text�I�u�W�F�N�g��ۑ�

    void Start() {
        //�X�R�A�̕\��
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
