using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // 이동 속도
    public float maxHealth; // 최대 체력
    public float armor; // 방어력
    public float recovery; // 회복

    private Vector3 moveVec; // 이동 벡터

    private float h, v;

    Animator anim;
    Rigidbody rigid;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        GetInput();
        Rotate();
    }
    private void FixedUpdate()
    {
        Move(); 
    }
    void GetInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }
    void Move()
    {
        moveVec = new Vector3(h, 0, v).normalized;

        rigid.velocity = moveVec * moveSpeed * Time.deltaTime;

        anim.SetBool("isMove", moveVec != Vector3.zero);

    }
    void Rotate()
    {
        transform.LookAt(transform.position + moveVec);
    }
}
