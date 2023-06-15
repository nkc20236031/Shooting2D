using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGenerator : MonoBehaviour {
    public GameObject Bonus;
    [SerializeField] private float span;
    float delta;

    void Update() {
        delta += Time.deltaTime;
        if (delta > span && GameDirector.kyori > 500) {
            delta = 0;
            GameObject go = Instantiate(Bonus);
            float py = Random.Range(-9f, 10f);
            go.transform.position = new Vector3 (py, 7, 0);
        }
    }
}
