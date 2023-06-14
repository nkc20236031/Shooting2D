using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleDirector : MonoBehaviour {
    
    void Start() {
        GameObject Score = GameObject.Find("Score");
        Score.GetComponent<Text>().text = ($"Score\n{GameDirector.kyori.ToString("D6")}");
        GameDirector.kyori = 0;
    }

    void Update() {
        if (Input.GetButtonDown("Start")) {
            SceneManager.LoadScene("GameScene");
        }
    }
}
