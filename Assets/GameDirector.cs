using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    [SerializeField] Image timeGauge;   //�^�C���Q�[�W��\������UI-Image�I�u�W�F�N�g��ۑ�
    [SerializeField] Text kyoriLabel;   //������\������UI-Text�I�u�W�F�N�g��ۑ�
    [SerializeField] float lastTime;    //�c�莞�Ԃ�ۑ�����ϐ�
    public static int kyori;            //������ۑ�����ϐ�

    void Start() {
        Application.targetFrameRate = 60;       //�t���[�����[�g(60)
        kyori = 0;
    }

    void Update() {
        //�c�莞�Ԃ����炷����
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 100f;

        //�c�莞�Ԃ��O�ɂȂ����烊���[�h
        if(lastTime < 0) {
            SceneManager.LoadScene("TitleScene");
        }

        //�i�񂾋�����\��
        if (kyori < 0) {
            kyori = 0;
        }
        kyori++;
        kyoriLabel.text = ($"{kyori.ToString("D6")}km");
    }
}