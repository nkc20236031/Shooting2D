using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    [SerializeField] GameObject bonus;      //�{�[�i�X�A�C�e���I�u�W�F�N�g��ۑ�
    [SerializeField] Image TimeGauge;       //�^�C���Q�[�W��\������UI-Image�I�u�W�F�N�g��ۑ�
    [SerializeField] Image HpBar;           //�̗̓Q�[�W��\������UI-Image�I�u�W�F�N�g��ۑ�
    [SerializeField] Text ScoreLabel;       //�X�R�A��\������UI-Text�I�u�W�F�N�g��ۑ�

    int score;                              //�X�R�A��ۑ�����ϐ�
    float hp;                               //�c��̗̑͂�ۑ�����ϐ�
    float span;                             //�e�̏������ԊԊu��ۑ�����ϐ�
    float delta;
    float lasttime;                         //�c�莞�Ԃ�ۑ�����ϐ�
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
        Application.targetFrameRate = 60;   //�t���[�����[�g(60)

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

        //�c�莞��
        lasttime -= Time.deltaTime;
        TimeGauge.fillAmount = lasttime / 480;

        //�c�莞�Ԃ܂��̗͑͂��O�ɂȂ�����^�C�g���V�[���Ɉړ�
        if (hp == 0 || TimeGauge.fillAmount <= 0) {
            BgmManager.Instance.Stop();
            ScoreDirector.GameScore = Score;
            SceneManager.LoadScene("TitleScene");
        }

        //�X�R�A��\��
        if (score < 0) {
            score = 0;
        }
        score += (score < 999999)? 1:0;
        ScoreLabel.text = ($"Score: {score.ToString("D6")}");

        //�{�[�i�X�A�C�e��
        delta += Time.deltaTime;
        if (delta > span) {
            delta = 0;
            GameObject go = Instantiate(bonus);
            float py = Random.Range(-8.5f, 9.5f);
            go.transform.position = new Vector3(py, 7, 0);
        }

        //�G�X�P�[�v�L�[������������
        if (Input.GetKeyDown(KeyCode.Escape)) {
            esc = true;
        } else if (Input.GetKeyUp(KeyCode.Escape)) {
            esc = false;
            del = 0;
        }

        //�Q�[���I��
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
