using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour {
    void Start() {
        //‰‰o‚ªŠ®—¹‚µ‚½‚çíœ
        ParticleSystem Effect = GetComponent<ParticleSystem>();
        Destroy(gameObject, Effect.main.duration);
    }
}
