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
    public float[] mPercentage;
    public string[] mItemName;

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

    // Get item for Percentage 
    float GetItemPercentage()
    {
        float[] probs = mPercentage;
        string[] items = mItemName;

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                Debug.Log(" 당첨 : " + items[i]);
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    // 플레이어가 아이템 가까이 가면 아이템 삭제하고 아이템 획득
    void GetItem()
    {
        if (mDistance < itemMagentDistance)
        {
            this.transform.position += new Vector3(Mathf.Lerp(myXDistance, pXDistance, Time.deltaTime), 0, Mathf.Lerp(myZDistance, pZDistance, Time.deltaTime * 0.01f));
        }

    }

    // 플레이어가 아이템 가까이 갔는지 감지하기
    void PlayerDistanceCheck()
    {
        mDistance = Vector3.Distance(myDistance, pDistance);
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



        GetItem();
        PlayerDistanceCheck();

        GetItemPercentage();
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
