using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GeneralEnemy : MonoBehaviour
{
    //monster states
    // private float maxHealth ;
    // private float health;
    // private float power;
    // private float speed;
    // private float knockback;
    // private float xp;
    // private bool isAlive;
    // private bool isMelee;
    // private bool isBoss;
    // private float sightRange;
    public EnemyStat _generalEnemyStat;
    

    



    //follow target v
    private NavMeshAgent nav;
    public Transform _player;
    private Rigidbody rb;
    private float distanceBtwEnemyAndPlayer;
    
    //Damaged Related
    private MeshRenderer _meshRenderer;
    
    

    //animation related
    private Animator enemyAnim;
    
    

    private void Awake()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        rb = gameObject.GetComponent<Rigidbody>();
        _player = GameObject.Find("Capsule").transform;
        _meshRenderer = gameObject.GetComponent<MeshRenderer>();
        enemyAnim = gameObject.GetComponent<Animator>();

        
    }

    void Update()
    {
        CalculateDistance();
        TwrdsTarget();
       // Debug.DrawLine(transform.position,Vector3.forward.normalized * distanceBtwEnemyAndPlayer,Color.yellow);
        //Debug.DrawLine(transform.position,Vector3.left.normalized * _generalEnemyStat.SightRange,Color.red);
    }

    

    void GetDmg(int dmg)
    {
        _generalEnemyStat.HP -= dmg;
        Debug.Log(_generalEnemyStat.HP);
        if(_generalEnemyStat.HP <= 0f)
        {
            _generalEnemyStat.IsAlive = false;
            gameObject.SetActive(false);
            _generalEnemyStat.HP = _generalEnemyStat.MaxHP;
        }
        
        //var isdamaged = distanceBtwEnemyAndPlayer<=;
        StartCoroutine(ChangeColor());


        //GetKnockBack();

    }

    IEnumerator ChangeColor()
    {
        // lerp를 이용한 컬러변환 근데 너무 느리다.
        // var redVal = new Vector4(1, 0, 0, 0);
        // var whiltVal = new Vector4(1, 1, 1, 0);
        // var colorVal = Vector4.Lerp(redVal, whiltVal, Mathf.Sin(Time.time)*2);
        // _meshRenderer.material.SetColor("_Color", colorVal);
        // yield return new WaitForSeconds(0.5f);
        while (true)
        {
            
            _meshRenderer.material.SetColor("_Color", new Vector4(1,0,0,0));
            yield return new WaitForSeconds(0.1f);
            _meshRenderer.material.SetColor("_Color", Color.white);
            yield return new WaitForSeconds(0.1f);
        }

    }
    void HealthRgn()
    {
        
    }
    void Attack()
    {
        if (distanceBtwEnemyAndPlayer <= _generalEnemyStat.AttackRange)
        {
            //attackanima
            //_player.gameObject.takeDamage(_generalEnemyStat.Damage); 
            StartCoroutine(AttackMotion(_generalEnemyStat.AttackDeley));
        }

      
    }

    IEnumerator AttackMotion(float attackDelay)
    {
        yield return new WaitForSeconds(attackDelay);
        
    }

    void CalculateDistance()
    {
        
        distanceBtwEnemyAndPlayer=Vector3.Distance(transform.position, _player.position);
        //return distanceBtwEnemyAndPlayer;
    }

    void TwrdsTarget()
    {
        if (distanceBtwEnemyAndPlayer <= _generalEnemyStat.SightRange&& distanceBtwEnemyAndPlayer>_generalEnemyStat.AttackRange)
        {
            transform.LookAt(_player);
            nav.destination = _player.position;
        }
        
        else
        {
            //원래위치?? 아님 제자리 정지??? 
            transform.Rotate(transform.forward);
            nav.destination = transform.localPosition;
        }
       
    }

    void GetKnockBack()
    {
        rb.AddForce(Vector3.back*Time.deltaTime ,ForceMode.Impulse);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetDmg(10);
        }
    }
}
