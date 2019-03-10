using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [HideInInspector] public Animator anim;
    [HideInInspector] CharacterController enemycontroller;
    [HideInInspector] NavMeshAgent nav;
    [HideInInspector] public GameObject playerCharecter;


    public float dist;
    public float attackRadius;
    public float ehp = 100f;
    public float radius = 10;
    float damage = 10f;
    bool alive = true;

    public bool attac=false;

    Vector3 EnemyVector;
    public float gravity;
    float jumpforce = 9f;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        playerCharecter = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        enemycontroller = GetComponent<CharacterController>();
    }

    void Update()
    {
        dist = Vector3.Distance(playerCharecter.transform.position, transform.position);
        actions();
    }

    void actions()
    {
        if (dist > radius && alive == true) idle();
        if (dist < radius && alive == true) walk();
        if (dist < attackRadius && alive == true) attack();
        if (ehp <= 0) Die();
    }
    void idle()
    {
        nav.enabled = false;

        anim.SetBool("Idle",true);
        anim.SetBool("Attack", false);
        anim.SetBool("Walk", false);
    }
    void attack()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Attack", true);
        anim.SetBool("Walk", false);

        nav.enabled = false;
    }
    void walk()
    {
        nav.enabled = true;
        nav.SetDestination(playerCharecter.transform.position);     
        
        anim.SetBool("Walk", true);
        anim.SetBool("Attack", false);
        anim.SetBool("Idle", false);
    }

    public void TakeDamageFromBullet(float amount, Vector3 hitPoint)
    {
        if (alive == false) return;
        anim.SetTrigger("Damage");
        nav.enabled = false;
        ehp -= amount;
        if (ehp <= 0) Die();
    }
    public void TakeDamageFromMelee(float amount)
    {
        if (alive == false) return;
        anim.SetTrigger("Damage");
        nav.enabled = false;
        ehp -= amount;
        if (ehp <= 0) Die();
    }
    public void Die()
    {
        alive = false;
        nav.enabled = false;

        anim.SetBool("Idle", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Walk", false);

        anim.SetBool("Death",true);
        Destroy(gameObject, 5);
    }

    public void jump()
    {
        gravity = jumpforce;
    }
    void egravity()
    {
        gravity = nav.transform.position.y;
        if (enemycontroller.isGrounded) gravity = 0;
        else gravity -= 10 * Time.deltaTime;
    }
}