using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offsett;

    public void UpdateHealthBar(float currentHealth ,float maksHealth)
    {
        slider.value =currentHealth / maksHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.position = target.position + offsett;
    }
}
