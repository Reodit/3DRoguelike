using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float moveSpeed = 10f; // 이동 속도
    public float maxHealth; // 최대 체력
    public float armor; // 방어력
    public float recovery; // 회복

    private Vector3 moveVec; // 이동 벡터

    private float h, v;
    
    // 회전
    private float turnSpeed = 180f;
    Vector3 velocity;
    Vector3 rot;



    Animator anim;
    Rigidbody rigid;
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Rotate();
        //Rotation();
    }

    private void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Move(h, v);
    }
    void Move(float h, float v)
    {
        moveVec.Set(h, 0, v);
        moveVec = moveVec.normalized * moveSpeed * Time.deltaTime;

        rigid.MovePosition(transform.position + moveVec);

        anim.SetBool("isMove", moveVec != Vector3.zero);

    }
    //{


    //    //moveVec = new Vector3(h, 0, v).normalized;

    //    //rigid.velocity = moveVec * moveSpeed * Time.deltaTime;

    //    anim.SetBool("isMove", moveVec != Vector3.zero);
    //}
    //void Turn()
    //{
    //    Quaternion rot = Quaternion.LookRotation()
    //}
    //void Rotate()
    //{
    //    transform.LookAt(transform.position + moveVec);
    //}


}
