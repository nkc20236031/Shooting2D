using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    [SerializeField] GameObject EnemyPre;       //“G‚ÌƒvƒŒƒnƒu‚ğ•Û‘¶‚·‚é•Ï”
    [SerializeField] GameObject aEnemyPre;
    [SerializeField] GameObject BossEnemyPre;
    GameObject go;
    float span = 1f;                            //“G‚ğo‚·ŠÔŠui•bj‚ğ•Û‘¶‚·‚é•Ï”
    float delta = 0;                            //Œo‰ßŠÔŒvZ—p
    int random;
    bool boss;

    void Start () {
        boss = false;
    }

    void Update() {
        //Œo‰ßŠÔ‚ğ‰ÁZ
        delta += Time.deltaTime;
        if (delta > span) {
            //ŠÔŒo‰ß‚ğ•Û‘¶‚µ‚Ä‚¢‚é•Ï”‚ğ‚OƒNƒŠƒA‚·‚é
            delta = 0;

            //“G‚ğ¶¬‚·‚é
            random = Random.Range(0, 10);
            if (random < 1) {
                go = Instantiate(aEnemyPre);
            } else {
                go = Instantiate(EnemyPre);
            }
            float py = Random.Range(-4.25f, 4.25f);
            go.transform.position = new Vector3(10, py, 0);

            //“G‚ğo‚·ŠÔŠu‚ğ™X‚É’Z‚­‚·‚é
            span -= (span > 0.5f)? 0.01f : 0f;
        }

        if (GameDirector.kyori > 10000 && boss == false) {
            boss = true;
            go = Instantiate(BossEnemyPre);
            go.transform.position = new Vector3(12, 0, 0);
        }
    }
}
