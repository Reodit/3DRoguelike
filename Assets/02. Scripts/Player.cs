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
    public float jumpPower = 5f;    // 점프력

    private Vector3 moveVec; // 이동 벡터

    private float h, v;
    private bool isJump;
    private bool jumpDown;

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
        jumpDown = Input.GetButtonDown("Jump");
        
        if(jumpDown && !isJump)
        {
            Jump();
        }
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
        rigid.MovePosition(transform.position + moveVec);

        anim.SetBool("isMove", moveVec != Vector3.zero);
    }
    void Turn()
    {
        if (h == 0 && v == 0) return;

        Quaternion rot = Quaternion.LookRotation(moveVec);

        rigid.rotation = Quaternion.Slerp(rigid.rotation, rot, rotateSpeed * Time.deltaTime); 
    }
    void Jump()
    {
        rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        anim.SetBool("isJump", true);
        anim.SetTrigger("Jump");
        isJump = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }
}
