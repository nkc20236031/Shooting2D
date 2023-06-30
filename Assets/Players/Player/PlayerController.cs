using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    [SerializeField] GameObject myShot;
    [SerializeField] Text shotLevel;

    Animator anim;                  //�A�j���[�^�[�R���|�[�l���g�̏���ۑ�����ϐ�
    Vector3 dir = Vector3.zero;     //�ړ�������ۑ�����ϐ�

    float delta;

    int level;                      //�e�̃��x����ۑ�����ϐ�
    float speed;                    //�v���C���[�̈ړ����x��ۑ�����ϐ�
    float span;                     //�e�̏������ԊԊu��ۑ�����ϐ�
    float shotSpeed;                //�e�̑��x��ۑ�����ϐ�

    public int Level {
        get { return level; }
        set { 
            level = value;
            level = Mathf.Clamp(level, 0, 12);
        }
    }

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    public float MyShotSpan {
        get { return span; }
        set { span = value; }
    }

    public float MyShotSpeed {
        get { return shotSpeed; }
        set { shotSpeed = value; }
    }

    void Start() {
        //�A�j���[�^�[�R���|�[�l���g�̏���ۑ�
        anim = GetComponent<Animator>();

        span = 0.25f;
        delta = 0;
        shotSpeed = 10;
        speed = 10f;
        level = 0;
    }

    void Update() {
        //�e���x���ύX
        if (Input.GetKeyDown(KeyCode.C)) {
            level++;
            if (level == 13) {
                level = 0;
            }
        }
        shotLevel.text = ($"ShotLevel: {level.ToString("D2")}");

        //�e�𐶐�����
        delta += Time.deltaTime;
        if (delta > span && Input.GetButton("Shot")) {
            delta = 0f;
            //���x���ɂ���ďo���e��
            for (int i = -level; i < level + 1; i++) {
                //�v���C���[�̌��ݒn���擾
                Vector3 p = transform.position;

                //�v���C���[�̉�]�p�x���擾
                Quaternion rot = Quaternion.identity;
                rot.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);

                //���ݒn�Ɗp�x���Z�b�g
                Instantiate(myShot, p, rot);
            }
            SeManager.Instance.Play("se_chun1");
        }

        //�ړ��������Z�b�g
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized * speed * Time.deltaTime;

        //��ʓ��ړ�����
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        //�A�j���[�V�����ݒ�
        if(dir.y == 0) {
            //�A�j���[�V�����N���b�v�yPlayer�z���Đ�
            anim.Play("Player");
        } else if(dir.y == 1) {
            anim.Play("PlayerL");
        } else if(dir.y == -1) {
            anim.Play("PlayerR");
        }
    }
}
