using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTestEnemy : MonoBehaviour
{
    public float hp = 100f;

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }

    }

}
