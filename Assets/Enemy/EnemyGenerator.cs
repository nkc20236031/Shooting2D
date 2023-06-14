using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    public GameObject enemyPre; //“G‚ÌƒvƒŒƒnƒu‚ð•Û‘¶‚·‚é•Ï”
    float delta;                //Œo‰ßŽžŠÔŒvŽZ—p
    float span;                 //“G‚ðo‚·ŠÔŠui•bj‚ð•Û‘¶‚·‚é•Ï”

    void Start() {
        delta = 0;
        span  = 1f;
    }

    void Update() {
        //Œo‰ßŽžŠÔ‚ð‰ÁŽZ
        delta += Time.deltaTime;

        if (delta > span) {
            //“G‚ð¶¬‚·‚é
            GameObject go = Instantiate(enemyPre);
            float py = Random.Range(-6f, 7f);
            go.transform.position = new Vector3(10, py, 0);

            //ŽžŠÔŒo‰ß‚ð•Û‘¶‚µ‚Ä‚¢‚é•Ï”‚ð‚OƒNƒŠƒA‚·‚é
            delta = 0;

            //“G‚ðo‚·ŠÔŠu‚ð™X‚É’Z‚­‚·‚é
            span -= (span > 0.5f)? 0.01f : 0f;
        }
    }
}










