using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager2 : MonoBehaviour
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
            GameManager.instance.finishText.gameObject.SetActive(false);
            GameManager.instance.finishPanel.SetActive(true);
            GameManager.instance.puanTextFinish.text = "Toplanan Bayrak sayýsý: " + RandomFlag.instance.flagCount.ToString();

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(go);
            }
        }
    }
}
