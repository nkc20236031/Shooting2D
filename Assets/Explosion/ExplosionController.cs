using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {
    void Start() {
        //‰‰o‚ªŠ®—¹‚µ‚½‚çíœ
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, particleSystem.main.duration);
    }
}
