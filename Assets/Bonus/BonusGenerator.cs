using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGenerator : MonoBehaviour {
    [SerializeField] GameObject Bonus;
    float span;
    float delta;

    void Start() {
        span = 5f;
        delta = 0f;
    }

    void Update() {
        //�p���[�A�b�v�ʂ𐶐�����i�X�R�A��500km�ȏ�̏ꍇ�j
        delta += Time.deltaTime;
        if (delta > span && GameDirector.kyori > 500) {
            delta = 0;
            GameObject go = Instantiate(Bonus);
            float py = Random.Range(-9f, 10f);
            go.transform.position = new Vector3 (py, 7, 0);
        }
    }
}
