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

    private Vector3 moveDir;
    private Vector3 moveVec; // 이동 벡터
    private Vector3 dodgeVec; // 회피 벡터
    private Vector3 attackVec; // 공격 벡터

    private float h, v;
    private bool isDodge;
    private bool dodgeDown;

    private bool isNormalAtk;
    private bool attackDown;

    private bool NormalAtkDelay;
    private float delayTime = 0.5f;
    private float timer = 0f;
    public int attackNum;

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

        if (dodgeDown && !isDodge && moveDir != Vector3.zero)
        {
            Dodge();
        }

        if (attackDown)
        {
            NormalAttack();
        }
        NormalAttackDelay();

        if (Input.GetKeyDown(KeyCode.E))
        {
            attackNum = Random.Range(1, 5);
            Debug.Log(attackNum);

        }
    }
    private void FixedUpdate()
    {
        Move();
        Turn();
    }
    void Move()
    {
        moveDir = new Vector3(h, 0, v).normalized;

        if (isNormalAtk)
        {
            moveDir = attackVec;
        }

        if (isDodge)
        {
            moveDir = dodgeVec;
        }
        rigid.MovePosition(transform.position + (moveDir * moveSpeed * Time.deltaTime));

        anim.SetBool("isMove", moveDir != Vector3.zero);
    }
    void Turn()
    {
        transform.LookAt(transform.position + moveDir) ;
        //if (h == 0 && v == 0) return;

        //else
        //{
        //    Quaternion rot = Quaternion.LookRotation(moveDir);

        //    //rigid.rotation = Quaternion.Slerp(rigid.rotation, rot, rotateSpeed * Time.deltaTime);

        //    transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotateSpeed);
        //}

    }
    void Dodge()
    {
        dodgeVec = moveDir;
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
            attackVec = moveDir;
            NormalAtkDelay = true;
            isNormalAtk = true;
            Debug.Log("Attack");
            anim.Play("NormalAttack");

            Invoke("NormalAttackEnd", delayTime);
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

    void Attack()
    {

    }
}