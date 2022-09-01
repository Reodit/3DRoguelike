using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTest : MonoBehaviour
{
    private float xPos;

    private float zPos;

    private Vector3 moveDir;
    private Rigidbody rb;
    public float speed = 3f;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        //rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        
        Debug.Log(rb.rotation);
        

    }


    // Update is called once per frame
    void Update()
    {
        //Camera.main.transform.position = transform.position;
        xPos = Input.GetAxisRaw("Horizontal");
        zPos = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(xPos, 0, zPos);
        transform.Translate(moveDir*speed*Time.deltaTime);
        //transform.position = moveDir * speed * Time.deltaTime;
    }
}
