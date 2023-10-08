using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public Animator animator;
    //public float bulletForce= 20f;

    [Range(0.1f, 2f)]
    [SerializeField] private float fireRate=0.5f;

    private float fireTimer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && fireTimer<=0f)
        {
            Shoot();
            animator.SetTrigger("shoot");
            fireTimer = fireRate;
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       // Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
       // rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
