using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float currentHealt=100f, maksHealth = 100f;

    public Transform target;
    [SerializeField] float speed=2f;
    [SerializeField] float rotateSpeed = 0.25f;
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] float enemyRange=2.5f;

    [SerializeField] HealthBar healthBar;

    float attackTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthBar = GetComponentInChildren<HealthBar>();
    }
    void Start()
    {
        currentHealt = maksHealth;
        healthBar.UpdateHealthBar(currentHealt, maksHealth);
      

    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

        if (target != null && Vector2.Distance(target.position, transform.position) <= enemyRange && attackTimer<=0)
        {
            animator.SetTrigger("attack");
      
            attackTimer = 1f;
          
        }
        AttackTime();


    }

    private void AttackTime()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            if (Vector2.Distance(target.position, transform.position) >= enemyRange)
            {
                rb.velocity = transform.right * speed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }

        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            animator.SetInteger("state", 1);
        }
        else
        {
            animator.SetInteger("state", 0);
        }


      

    }
    private void RotateTowardsTarget()
    {
        Vector2 targetDirection= target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.Euler(0, 0, angle);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);

    }
    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = null;
        }
        else if(collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(35f);
            Destroy(collision.gameObject);
         
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealt -= damageAmount;
        healthBar.UpdateHealthBar(currentHealt,maksHealth);

        if (currentHealt <=0)
        {
            GameManager.instance.puan += 3;
           Destroy(this.gameObject);
        }

    }

    public void AttackAnim()
    {
        PlayerMovement.instance.TakeDamage(15f);
    }
}
