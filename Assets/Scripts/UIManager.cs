using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.puan <= 0)
        {
            Time.timeScale = 0;
            GameManager.instance.finishText.text = "Görevi tamamlayamadýnýz";
            GameManager.instance.finishText.GetComponent<TMP_Text>().color = Color.red;
            GameManager.instance.finishPanel.SetActive(true);
            GameManager.instance.puanTextFinish.text = "Puanýnýz: " + ((int)GameManager.instance.puan).ToString();

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(go);
            }
        }
    }
}
