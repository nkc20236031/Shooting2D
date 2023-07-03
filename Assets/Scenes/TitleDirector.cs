using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {
    [SerializeField] Text Score;    //�X�R�A��\�����邷��UI-Text�I�u�W�F�N�g��ۑ�
    bool esc;
    float limit;
    float delta;

    void Start() {
        esc = false;
        limit = 1;
        delta = 0;

        //�X�R�A�̕\��
        string ScoreRec = ScoreDirector.GameScore.ToString("D6");
        Score.text = ScoreRec;
    }

    void Update() {
        //z or leftctrl or mouse0
        if (Input.GetButtonDown("Start")) {
            SceneManager.LoadScene("GameScene");
        }

        //�G�X�P�[�v�L�[������������
        if (Input.GetKeyDown(KeyCode.Escape)) {
            esc = true;
        } else if (Input.GetKeyUp(KeyCode.Escape)) {
            esc = false;
            delta = 0;
        }

        //�Q�[���I��
        if (esc) {
            delta += Time.deltaTime;
            if (delta > limit) {
                delta = 0;
                Application.Quit();
            }
        }
    }
}
