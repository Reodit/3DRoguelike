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

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        GetInput();
        Move();
        Rotate();
    }
    void GetInput()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }
    void Move()
    {

        moveVec = new Vector3(h, 0, v).normalized;

        float param = moveVec.magnitude;

        if((h==0f) && (v==0f)) { param = 0.0f; }
        else 
        {
            param = 1.0f; 
        }
        transform.position += moveVec * moveSpeed * Time.deltaTime;

        const float LerpSpeed = 0.05f;
        speed = Mathf.Lerp(speed, param, LerpSpeed);
        anim.SetFloat("moveSpeed", speed);
    }
    void Rotate()
    {
        transform.LookAt(transform.position + moveVec);
    }
}
