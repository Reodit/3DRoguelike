using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject obj;
    public GameObject player;
    GameObject myItem;
    public float regenTime;
    RaycastHit hitInfo;
    private float mDistance;
    public float itemMagentDistance = 30;

    private Vector3 myDistance;
    private Vector3 pDistance;

    private float myXDistance;
    private float myZDistance;
    private float pXDistance;
    private float pZDistance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // 아이템 추가 획
    void GetAdditionalItem()
    {
        // UI 띄우ㄱ
    }   

    // 플레이어가 아이템 가까이 가면 아이템 삭제하고 아이템 획득
    void GetItem()
    {
        Debug.Log("mDistance : " + mDistance);
        if (mDistance < itemMagentDistance)
        {
            this.transform.position += new Vector3(Mathf.Lerp(myXDistance, pXDistance, Time.deltaTime), 0, Mathf.Lerp(myZDistance, pZDistance, Time.deltaTime * 0.01f));
        }

    }

    // 플레이어가 아이템 가까이 갔는지 감지하기
    void PlayerDistanceCheck()
    {
        mDistance = Vector3.Distance(myDistance, pDistance);
        Debug.Log("mDistance : " + mDistance);
    }


    void Start()
    {
        myDistance = this.transform.position;
        pDistance = player.transform.position;

        myXDistance = this.transform.position.x;
        pXDistance = player.transform.position.x;

        myZDistance = this.transform.position.z;
        pZDistance = player.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(this.transform.position, Vector3.forward * 10, Color.red);

        //if(Physics.Raycast(this.transform.position, Vector3.forward, out hitInfo, 30f))
        //{
        //    Debug.Log(hitInfo.transform.name);
        //}

        myDistance = this.transform.position;
        pDistance = player.transform.position;
        pXDistance = player.transform.position.x;
        pZDistance = player.transform.position.z;


        Debug.Log("myDistance : " + myDistance);
        Debug.Log("pDistance : " + pDistance);
        GetItem();
        PlayerDistanceCheck();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(this.obj)
            {
                Destroy(this.obj);
            }
        }
    }
}
