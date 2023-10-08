using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missions : MonoBehaviour
{
    public GameObject nextTarget;
    public GameObject missionObject;

    public Image image;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.instance.finishPoint.SetActive(true);
                RotateTowards.instance.target = nextTarget;
                missionObject.SetActive(true);           
                Destroy(this.gameObject);

            }
            
            image.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            image.gameObject.SetActive(false);
        }
    }
}
