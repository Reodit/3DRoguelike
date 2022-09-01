using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // 이동 속도
    private Vector3 moveVec; // 이동 벡터

    private float h, v;
    private float speed;

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

        float param = moveVec.magnitude;

        if (moveVec == Vector3.zero) { param = 0.01f; }
        else { param = 1.0f; }
        rigid.velocity = moveVec * moveSpeed * Time.deltaTime;

        const float LerpSpeed = 0.05f;
        speed = Mathf.Lerp(speed, param, LerpSpeed);
        anim.SetFloat("moveSpeed", speed);
    }
    void Rotate()
    {
        transform.LookAt(transform.position + moveVec);
    }
}
