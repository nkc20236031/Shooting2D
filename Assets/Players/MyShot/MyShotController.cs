using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShotController : MonoBehaviour {
    public EffectController Collision;
    PlayerController msc;

    void Start () {
        msc = GameObject.Find("Player").GetComponent<PlayerController>();
        msc.MyShotSpeed = 10f;

        Destroy(gameObject, 2f);
    }

    void Update() {
        //�e�̈ړ�
        transform.position += transform.up * msc.MyShotSpeed * Time.deltaTime;
    }
    
    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        //�G�l�~�[�ɓ��������ꍇ
        if (obj.tag == "Enemy") {
            //SE
            SeManager.Instance.Play("se_explode11");

            //Effect
            Instantiate(Collision, transform.localPosition, Quaternion.identity);
        }
    }
}
