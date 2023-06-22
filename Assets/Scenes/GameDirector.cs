using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    [SerializeField] GameObject bonus;
    [SerializeField] Image timeGauge;           //�^�C���Q�[�W��\������UI-Image�I�u�W�F�N�g��ۑ�
    [SerializeField] Text kyoriLabel;           //������\������UI-Text�I�u�W�F�N�g��ۑ�
    public static int kyori;                    //������ۑ�����ϐ�
    float lastTime;                             //�c�莞�Ԃ�ۑ�����ϐ�
    float span;
    float delta;

    void Start() {
        Application.targetFrameRate = 60;       //�t���[�����[�g(60)
        kyori = 0;
        lastTime = 100f;                        //�c�莞��
        span = 10f;
        delta = 0;
    }

    void Update() {
        //�c�莞�Ԃ����炷����
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 100f;

        //�c�莞�Ԃ��O�ɂȂ�����^�C�g���V�[���Ɉړ�
        if(lastTime < 0) {
            SceneManager.LoadScene("TitleScene");
        }

        //�i�񂾋�����\��
        if (kyori < 0) {
            kyori = 0;
        }
        kyori++;
        kyoriLabel.text = ($"Score: {kyori.ToString("D6")}");

        //�{�[�i�X��
        delta += Time.deltaTime;
        if (delta > span) {
            delta = 0;
            GameObject go = Instantiate(bonus);
            float py = Random.Range(-9f, 10f);
            go.transform.position = new Vector3(py, 7, 0);
        }
    }
}
