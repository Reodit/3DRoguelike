using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameObject obj;

    
    // 몹이 죽었을 때 아이템 떨어뜨리기
    void ItemInstancing()
    {
        GameObject myItem = Instantiate(obj);
    }

    // 플레이어가 아이템 가까이 가면 아이템 삭제하고 아이템 획득
    void GetItem()
    {

    }

    // 플레이어가 




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
