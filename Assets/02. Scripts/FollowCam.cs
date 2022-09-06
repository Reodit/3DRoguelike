using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // 타겟 설정
    public Transform target;
    public Vector3 offset = new Vector3(0f, 8f, -4f);
    public Vector3 orbit = new Vector3(60f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        transform.position = target.position + offset;
        transform.rotation = Quaternion.Euler(orbit);
    }
}
