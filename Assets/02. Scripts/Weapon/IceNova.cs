using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceNova : MonoBehaviour
{
    public LayerMask whatIsEnemy;
    public ParticleSystem iceNovaParticle;
    public AudioSource iceNovaAudio;

    public float weaponDamage = 10f;
    public float area = 2.5f;
    public float cooldown = 5f;
    public bool isCast = true;

    private void Start()
    {
        StartCoroutine("IceNovaCast");
    }

    IEnumerator IceNovaCast()
    {
        while (isCast)
        {
            iceNovaParticle.Play();
            Collider[] colliders = Physics.OverlapSphere(transform.position, area, whatIsEnemy);

            for (int i = 0; i < colliders.Length; i++)
            {
                WeaponTestEnemy targetEnemy = colliders[i].GetComponent<WeaponTestEnemy>();

                float damage = weaponDamage;

                targetEnemy.TakeDamage(damage);
            }
            Debug.Log("Ice Nova");
           yield return new WaitForSeconds(cooldown);
        }
    }

}
