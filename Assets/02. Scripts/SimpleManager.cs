using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleManager : MonoBehaviour
{
    public GameObject obj;
    public Transform pool;
    void Start()
    {
        Invoke("Instancing", 3f);
        Instancing();
    }

    void Instancing()
    {
       Instantiate(obj, new Vector3(Random.Range(0,30), 0, Random.Range(0, 30)), Quaternion.identity, pool);
    }

}
