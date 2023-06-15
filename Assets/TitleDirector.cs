using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleDirector : MonoBehaviour {
    
    void Start() {
        //ÉXÉRÉA(km)
        GameObject Score = GameObject.Find("Score");
        Score.GetComponent<Text>().text = ($"Score\n{GameDirector.kyori.ToString("D6")}");
        GameDirector.kyori = 0;
    }

    void Update() {
        //z or leftctrl or mouse0
        if (Input.GetButtonDown("Start")) {
            SceneManager.LoadScene("GameScene");
        }
    }
}
