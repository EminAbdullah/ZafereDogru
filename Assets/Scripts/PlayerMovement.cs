using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;     

    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    private Animator animator;

    [SerializeField] private HealthBar healthBar;
    public float currentHealth = 100f, maksHealth = 100f;


    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        healthBar = GetComponentInChildren<HealthBar>();
    }

    void Start()
    {
        currentHealth = maksHealth;
        healthBar.UpdateHealthBar(currentHealth, maksHealth);


    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        Vector2 lookDir= mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg ;
        rb.rotation = angle;
        if (movement.x !=0 || movement.y!= 0)
        {
            animator.SetInteger("state", 1);
        }
        else
        {
            animator.SetInteger("state", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(10f);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.UpdateHealthBar(currentHealth, maksHealth);

        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            GameManager.instance.puan = 0;
            GameManager.instance.finishText.text = "Görevi tamamlayamadýnýz";
            GameManager.instance.finishText.GetComponent<TMP_Text>().color = Color.red;
            GameManager.instance.finishPanel.SetActive(true);
            GameManager.instance.puanTextFinish.text = "Puanýnýz: " + ((int)GameManager.instance.puan).ToString();

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(go);
            }
            Destroy(this.gameObject);
        }

    }

}
