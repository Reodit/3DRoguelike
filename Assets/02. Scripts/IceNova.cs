using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceNova : MonoBehaviour
{
    public LayerMask whatIsProp;
    public ParticleSystem iceNovaParticle;
    public AudioSource iceNovaAudio;

    public float damage = 10f;
    public float area = 10f;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, area, whatIsProp);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            //targetRigidbody.AddExplosionForce(explosionForece, transform.position, area);

            //Prop targetProp = colliders[i].GetComponent<Prop>();

            //float damage = CalculateDamage(colliders[i].transform.position);

            //targetProp.TakeDamage(damage);
        }


        iceNovaParticle.transform.parent = null;

        iceNovaAudio.Play();
        //explosionAudio.Play();

        //GameManager.instance.OnBallDestroy();

        Destroy(iceNovaParticle.gameObject, iceNovaParticle.duration);
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
