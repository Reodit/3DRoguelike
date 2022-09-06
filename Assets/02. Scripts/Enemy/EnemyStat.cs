using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "General Enemy",menuName = "Scriptable Object/Enemy Data",order = int.MaxValue)]
public class EnemyStat : ScriptableObject
{
    [SerializeField]
    private string enemyName;

    public string EnemyName
    {
        get { return enemyName; }
    }
    [SerializeField]
    private float maxHp ;
    public float MaxHP { get { return maxHp; } }
    [SerializeField]
    private float hp;
    public float HP { get { return hp; }
        set { hp = value; }
    }
    [SerializeField]
    private float damage;
    public float Damage { get { return damage; } }
    [SerializeField]
    private float speed;
    public float Speed {get { return speed; } }
    [SerializeField]
    private float knockback;
    public float KnockBack { get { return knockback; } }
    [SerializeField]
    private float xp;
    public float Xp {get { return xp; } }
    [SerializeField]
    private bool isAlive;

    public bool IsAlive
    {
        get
        {
            return isAlive;
        }
        set
        {
            isAlive = value;
        }
    }

    [SerializeField]
    private bool isMelee;
    public bool IsMelee { get { return isMelee; } }
    [SerializeField]
    private bool isBoss;
    public  bool IsBoss { get { return isBoss; } }
    [SerializeField]
    private float sightRange;
    public float SightRange { get { return sightRange; } }
    [SerializeField] private float attackRange;
    public float AttackRange { get { return attackRange; } }

    [SerializeField] private float attackDeley;
    public float AttackDeley { get { return attackDeley; }  }
}
