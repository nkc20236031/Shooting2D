using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour {
    void Start() {
        //���o������������폜
        ParticleSystem Effect = GetComponent<ParticleSystem>();
        Destroy(gameObject, Effect.main.duration);
    }
}
