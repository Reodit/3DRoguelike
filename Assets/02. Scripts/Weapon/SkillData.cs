using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill Data", menuName = "Scriptable Object/Skill Data", order = int.MaxValue)]
public class SkillData : ScriptableObject
{
    [SerializeField]
    private string skillName;
    public string SkillName { get { return skillName; } }

    [SerializeField]
    private bool isUlti;
    public bool IsUlti { get { return isUlti; } }

    [SerializeField]
    private float skillDamage;
    public float SkillDamage { get { return skillDamage; } }

    [SerializeField]
    private float skillArea;
    public float SkillArea { get { return skillArea; } }

    [SerializeField]
    private float skillSpeed;
    public float SkillSpeed { get { return skillSpeed; } }

    [SerializeField]
    private float skillAmount;
    public float SkillAmount { get { return skillAmount; } }

    [SerializeField]
    private float skillCooldown;
    public float SkillCooldown { get { return skillCooldown; } }

    [SerializeField]
    private float skillDuration;
    public float SkillDuration { get { return skillDuration; } }

    [SerializeField]
    private float skillKnockback;
    public float SkillKnockback { get { return skillKnockback; } }

}
