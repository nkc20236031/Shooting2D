using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyShotGenerator : MonoBehaviour {
    [SerializeField] private GameObject myShot;
    [SerializeField] private GameObject player;
    [SerializeField] private Text shotLevel;
    [SerializeField] private float span;
    public static int level;
    float delta;

    void Start() {
        level = 0;
    }

    void Update() {
        //レベルチート
        if (Input.GetKeyDown(KeyCode.C)) {
            level++;
            if (level > 12) {
                level = 0;
            }
        }
        shotLevel.text = ($"ShotLevel: {level}");

        //クローン
        delta += Time.deltaTime;
        if (delta > span && Input.GetKey(KeyCode.Z)) {
            delta = 0f;
            //レベルによって出す弾数
            for (int i = 0; i < level + 1; i++) {
                GameObject go = Instantiate(myShot);
                go.transform.position = player.transform.position + new Vector3(0.5f, 0, 0);
                go.transform.eulerAngles = new Vector3(0, 0, -90 + (15f * i));
            }
            for (int i = 1; i <= level; i++) {
                if (i < 12) {
                    GameObject go = Instantiate(myShot);
                    go.transform.position = player.transform.position + new Vector3(0.5f, 0, 0);
                    go.transform.eulerAngles = new Vector3(0, 0, -90 + (-15f * i));
                }
            }
        }
    }
}
