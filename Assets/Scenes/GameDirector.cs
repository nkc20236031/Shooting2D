using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    [SerializeField] GameObject bonus;
    [SerializeField] Image HpBar;           //�^�C���Q�[�W��\������UI-Image�I�u�W�F�N�g��ۑ�
    [SerializeField] Text kyoriLabel;       //������\������UI-Text�I�u�W�F�N�g��ۑ�
    public static int kyori;                //������ۑ�����ϐ�
    public static float hp;                               //�c�莞�Ԃ�ۑ�����ϐ�
    float span;
    float delta;

    void Start() {
        Application.targetFrameRate = 60;   //�t���[�����[�g(60)
        kyori = 0;
        hp = 100f;                          //�̗�
        span = 10f;
        delta = 0;
    }

    void Update() {
        HpBar.fillAmount = hp / 100;
        
        //�c�莞�Ԃ��O�ɂȂ�����^�C�g���V�[���Ɉړ�
        if(hp < 0) {
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
            float py = Random.Range(-8.5f, 9.5f);
            go.transform.position = new Vector3(py, 7, 0);
        }
    }
}
