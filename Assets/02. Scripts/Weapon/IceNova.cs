using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceNova : MonoBehaviour
{

    public LayerMask whatIsEnemy;
    public ParticleSystem iceNovaParticle;
    public AudioSource iceNovaAudio;
    public SkillData[] skillData;
    [Range(1, 3)]public int skillLevel;

    public float skillDamage = 10f;
    public float skillArea = 2.5f;
    public float skillCooldown = 5f;

    public bool isCooldown = true;

    private void Start()
    {

    }

    private void Update()
    {
        IceNovaCooldown();
    }

    public void IceNovaCast()
    {
        if (isCooldown)
        {
            skillDamage = skillData[skillLevel - 1].SkillDamage;
            skillArea = skillData[skillLevel - 1].SkillArea;
            skillCooldown = skillData[skillLevel - 1].SkillCooldown;
            iceNovaParticle.Play();
            iceNovaAudio.Play();
            iceNovaParticle.transform.localScale = new Vector3(skillArea, skillArea, skillArea);

            Collider[] colliders = Physics.OverlapSphere(transform.position, 2.5f * skillArea, whatIsEnemy);

            for (int i = 0; i < colliders.Length; i++)
            {
                WeaponTestEnemy targetEnemy = colliders[i].GetComponent<WeaponTestEnemy>();

                float damage = skillDamage;

                targetEnemy.TakeDamage(damage);
            }
            isCooldown = false;
        }
    }

    void IceNovaCooldown()
    {
        if(!isCooldown)
        {
            skillCooldown -= Time.deltaTime;
            if (skillCooldown <= 0)
            {
                isCooldown = true;
                skillCooldown = skillData[skillLevel - 1].SkillCooldown;
            }
        }
    }

}
