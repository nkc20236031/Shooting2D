using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour {
    public Speed SpeedUp;
    public LimitEffect StrengthUp;
    public LimitEffect Heeling;
    PlayerController pc;
    GameDirector gd;

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

        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        Destroy(gameObject, 5f);
    }

    void Update() {
        //�������x
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.tag == "Player") {
            bonus(random);
            Destroy(gameObject);
        }
    }

    //�F�ʌ���
    void bonus(int num) {
        switch (num) {
            case 0:
                //�e���x���{�P
                pc.Level++;

                //Effect
                Instantiate(StrengthUp, transform.localPosition, Quaternion.identity);
                break;
            case 1:
                //�̗́{�Q�T�A�e���x���[�P
                gd.HP += 25;
                pc.Level--;

                //Effecct
                Instantiate(Heeling, transform.localPosition, Quaternion.identity);
                break;
            case 2:
                //�v���C���[�ړ����x1.5�{�A�v���C���[�e�ړ����x�������Ԋu2�{
                pc.Speed = 15;
                pc.MyShotSpan = 0.125f;
                pc.MyShotSpeed = 20;

                //Effect
                Instantiate(SpeedUp, transform.localPosition, Quaternion.identity);
                break;
        }
        //SE
        SeManager.Instance.Play("se_power_up1");
    }
}
