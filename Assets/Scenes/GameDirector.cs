using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    [SerializeField] GameObject bonus;
    [SerializeField] Image HpBar;           //�̗̓Q�[�W��\������UI-Image�I�u�W�F�N�g��ۑ�
    [SerializeField] Text ScoreLabel;       //�X�R�A��\������UI-Text�I�u�W�F�N�g��ۑ�

    int score;                              //�X�R�A��ۑ�����ϐ�
    float hp;                               //�c��̗̑͂�ۑ�����ϐ�
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
        Application.targetFrameRate = 60;   //�t���[�����[�g(60)
        span = 10f;
        delta = 0;

        hp = 100;
        score = 0;
    }

    void Update() {
        HpBar.fillAmount = hp / 100;
        
        //�c�莞�Ԃ��O�ɂȂ�����^�C�g���V�[���Ɉړ�
        if (hp == 0) {
            ScoreDirector.GameScore = Score;
            SceneManager.LoadScene("TitleScene");
        }

        //�i�񂾋�����\��
        if (score < 0) {
            score = 0;
        }
        score++;
        ScoreLabel.text = ($"Score: {score.ToString("D6")}");

        //�{�[�i�X��
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
