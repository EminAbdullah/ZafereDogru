using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinishTask : MonoBehaviour
{
    public Image image;
    public GameObject flag2;
    public GameObject missionObject;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            image.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                Time.timeScale = 0f;
                GameManager.instance.finishText.text = "Tebrikler Görevi baþarýyla tamamladýnýz";
                GameManager.instance.finishPanel.SetActive(true);
                GameManager.instance.puanTextFinish.text = "Puanýnýz: " +((int)GameManager.instance.puan).ToString();
               
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    Destroy(go);
                }
                foreach (GameObject enemyBullet in GameObject.FindGameObjectsWithTag("EnemyBullet"))
                {
                    Destroy(enemyBullet);
                }
                foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("EnemyBullet"))
                {
                    Destroy(bullet);
                }
                image.gameObject.SetActive(false);
                flag2.gameObject.SetActive(true);
                missionObject.SetActive(false);

            }

          
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
