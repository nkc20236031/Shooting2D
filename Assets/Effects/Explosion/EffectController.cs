using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour {
    GameDirector gd;
    bool one = true;

    void Start() {
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        //演出が完了したら削除
        ParticleSystem Effect = GetComponent<ParticleSystem>();
        Destroy(gameObject, Effect.main.duration);
    }

    void OnParticleCollision(GameObject obj) {
        if (obj.tag == "Player" && gd.Attack && one) {
            //プレイヤーのScore: -1500, HP: -25
            gd.Score -= 1500;
            gd.HP -= 25;
            one = false;
        }
    }
}
