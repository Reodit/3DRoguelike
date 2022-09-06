using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotateSpeed = 15f; // 회전 속도
    public float moveSpeed = 10f;   // 이동 속도
    public float maxHealth;         // 최대 체력
    public float armor;             // 방어력
    public float recovery;          // 회복
    //public float jumpPower = 5f;    // 점프력

    private Vector3 moveVec; // 이동 벡터
    private Vector3 dodgeVec; // 회피 벡터
    private Vector3 attackVec; // 공격 벡터

    private float h, v;
    private bool isDodge;
    private bool dodgeDown;

    private bool isNormalAtk;
    private bool attackDown;

    private bool NormalAtkDelay;
    private float delayTime = 2f;
    private float timer = 0f;

    Animator anim;
    Rigidbody rigid;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        dodgeDown = Input.GetButtonDown("Jump");
        attackDown = Input.GetButtonDown("NormalAttack");

        if (dodgeDown && !isDodge && moveVec != Vector3.zero)
        {
            Dodge();
        }

        if (attackDown)
        {
            NormalAttack();
        }
        NormalAttackDelay();
    }
    private void FixedUpdate()
    {
        Move(h, v);
        Turn();
    }
    void Move(float h, float v)
    {
        moveVec.Set(h, 0, v);
        moveVec = moveVec.normalized * moveSpeed * Time.deltaTime;

 
        
        if (isDodge)
        {
            moveVec = dodgeVec;
        }
        rigid.MovePosition(transform.position + moveVec);

        anim.SetBool("isMove", moveVec != Vector3.zero);
    }
    void Turn()
    {
        if (h == 0 && v == 0) return;

        Quaternion rot = Quaternion.LookRotation(moveVec);

        rigid.rotation = Quaternion.Slerp(rigid.rotation, rot, rotateSpeed * Time.deltaTime);
    }
    void Dodge()
    {
        dodgeVec = moveVec;
        anim.SetTrigger("Dodge");
        isDodge = true;

        Invoke("DodgeEnd", 1.0f);
    }
    void DodgeEnd()
    {
        isDodge = false;
    }   
    void NormalAttack()
    {
        if (!NormalAtkDelay)
        {
            attackVec = moveVec;
            NormalAtkDelay = true;
            isNormalAtk = true;
            Debug.Log("Attack");
            anim.SetTrigger("NormalAttack");

            Invoke("NormalAttackEnd", 2.0f);
        }
    }
    void NormalAttackEnd()
    {
        isNormalAtk = false;
    }
    void NormalAttackDelay()
    {
        if (NormalAtkDelay)
        {
            timer += Time.deltaTime;
            if (timer >= delayTime)
            {
                timer = 0f;
                NormalAtkDelay = false;
            }
        }
    }

}