using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour {
    public Speed Speedup;
    public LimitEffect Strengthup;
    public LimitEffect Heeling;
    [SerializeField] Sprite Red;
    [SerializeField] Sprite Green;
    [SerializeField] Sprite Blue;
    SpriteRenderer image;
    int random;
    float speed;

    void Start() {
        //�摜�̕ύX
        image = GetComponent<SpriteRenderer>();
        Sprite[] sp = {Red, Green, Blue};
        random = Random.Range(0, sp.Length);
        image.sprite = sp[random];

        speed = 3f;
    }

    void Update() {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            bonus(random);
            Destroy(gameObject);
        }
    }

    //�F�ʌ���
    void bonus(int num) {
        switch (num) {
            case 0:     //�V���b�gUP
                PlayerController.level += (PlayerController.level == 12) ? 0 : 1;
                Instantiate(Strengthup, transform.localPosition, Quaternion.identity);
                break;
            case 1:     //���\�_�E����hp��
                PlayerController.level -= (PlayerController.level == 0) ? 0 : 1;
                PlayerController.speed = 10;
                GameDirector.hp += 10;
                Instantiate(Heeling, transform.localPosition, Quaternion.identity);
                break;
            case 2:     //�X�s�[�hUP
                PlayerController.speed = 15;
                Instantiate(Speedup, transform.localPosition, Quaternion.identity);
                break;
        }
    }
}
