using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    public Text KyoriLabel;         //������\������UI-Text�I�u�W�F�N�g��ۑ�����ϐ�
    public Image TimeGauge;         //�^�C���Q�[�W��\������UI
    public static float LastTime;   //�c�莞�Ԃ�ۑ�����ϐ�
    int Kyori;                      //������ۑ�����ϐ�

    void Start() {
        Application.targetFrameRate = 60;
        Kyori = 0;
        LastTime = 100f;    //�c�莞��100�b
    }

    void Update() {
        //�c�莞�Ԃ����炷����
        LastTime -= Time.deltaTime;
        TimeGauge.fillAmount = LastTime / 100f;

        //�c�莞�Ԃ�0�ɂȂ�����
        if (LastTime < 0) {
            SceneManager.LoadScene("TitleScene");
        }

        //�i�񂾋�����\��
        Kyori++;
        KyoriLabel.text = ($"{Kyori.ToString("D6")}km");
    }
}
