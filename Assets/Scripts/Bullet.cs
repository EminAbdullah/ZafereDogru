using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 10)]
    public float speed = 10f;
    // public GameObject hitEffect;

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 2f;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,lifeTime);
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }

}
