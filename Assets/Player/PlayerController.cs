using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Vector2 range;
    [SerializeField] private float speed;
    Animator anim;
    Vector3 dir = Vector3.zero;     //�ړ����@��ۑ�����ϐ�

    void Start() {
        //�A�j���[�^�[�R���|�[�l���g�̏���ۑ�
        anim = GetComponent<Animator>();
    }

    void Update() {
        //�ړ��������Z�b�g
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;

        //��ʓ��ړ�����
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -range.x, range.x);
        pos.y = Mathf.Clamp(pos.y, -range.y, range.y);
        transform.position = pos;

        //�A�j���[�V�����ݒ�
        if(dir.y == 0) {
            //�A�j���[�V�����N���b�v�yPlayer�z���Đ�
            anim.Play("Player");
        } else if(dir.y > 0) {
            anim.Play("PlayerL");
        } else if( dir.y < 0) {
            anim.Play("PlayerR");
        }
    }
}
