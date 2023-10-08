using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{

    public Transform target;
    public float speed=5f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    private Animator animator;

    public float distanceToShoot = 5f;

    public float distanceToStop = 3f;

    public float fireRate;
    private float timeToFire;

    public GameObject bulletPrefab;
    public Transform firingPoint;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] float currentHealt = 100f, maksHealth = 100f;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        healthBar = GetComponentInChildren<HealthBar>();
        rb = GetComponent<Rigidbody2D>();
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

        if (target != null && Vector2.Distance(target.position, transform.position) <= distanceToShoot)
        {
            Shoot();
        }
        
    }

  

    private void Shoot()
    {
      
        if (timeToFire <=0)
        {
           GameObject enemyBullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            enemyBullet.gameObject.GetComponent<Bullet>().speed = 6f;
            animator.SetTrigger("shoot");
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
            {
                rb.velocity = transform.right * speed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        
        if (rb.velocity.x !=0 || rb.velocity.y !=0)
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
            PlayerMovement.instance.TakeDamage(5f);
            target = null;
        }
        else if(collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(25f);
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealt -= damageAmount;
        healthBar.UpdateHealthBar(currentHealt, maksHealth);

        if (currentHealt <= 0)
        {
            GameManager.instance.puan += 5;
            Destroy(this.gameObject);
        }

    }
}
