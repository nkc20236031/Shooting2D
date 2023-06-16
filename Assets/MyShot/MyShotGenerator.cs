using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyShotGenerator : MonoBehaviour {
    [SerializeField] GameObject myShot;
    [SerializeField] GameObject player;
    [SerializeField] Text shotLevel;
    public static int level;
    float span;
    float delta;

    void Start() {
        level = 0;
        span = 0.5f;
        delta = 0;
    }

    void Update() {
        //レベル変更
        if (Input.GetKeyDown(KeyCode.C)) {
            level ++;
            if (level == 13) {
                level = 0;
            }
        }
        shotLevel.text = ($"ShotLevel: {level.ToString("D2")}");

        //弾を生成する
        delta += Time.deltaTime;
        if (delta > span && Input.GetKey(KeyCode.Z)) {
            delta = 0f;
            //レベルによって出す弾数
            for (int i = 0; i < level + 1; i++) {
                GameObject go = Instantiate(myShot);
                go.transform.position = player.transform.position;
                Vector3 r = transform.root.eulerAngles + new Vector3(0, 0, -90 + (15f * i));
                go.transform.rotation = Quaternion.Euler(r);
            }
            for (int i = 1; i <= level; i++) {
                if (i < 12) {
                    GameObject go = Instantiate(myShot);
                    go.transform.position = player.transform.position;
                    Vector3 r = transform.root.eulerAngles + new Vector3(0, 0, -90 + (-15f * i));
                    go.transform.rotation = Quaternion.Euler(r);
                }
            }
        }
    }
}
