using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomFlag : MonoBehaviour
{
    public static RandomFlag instance;

    private void Awake()
    {
        instance = this;
    }
    public GameObject[] flags;
    public TMP_Text flagText;
    public int flagCount;


    // Start is called before the first frame update
    void Start()
    {
        flagCount = 0;
       
        CloseAllFlags();
        GameObject flag= flags[Random.Range(0, flags.Length)].gameObject;
        flag.SetActive(true);
        RotateTowards.instance.target= flag;
    }

    private void Update()
    {
        flagText.text = flagCount.ToString();
        if (PlayerMovement.instance.currentHealth<=0)
        {
            GameManager.instance.finishText.gameObject.SetActive(false);
            GameManager.instance.finishPanel.SetActive(true);
            GameManager.instance.puanTextFinish.text = "Toplanan Bayrak sayýsý: " +flagCount.ToString();

        }
    }

    public void CloseAllFlags()
    {
        for (int i = 0; i < flags.Length; i++)
        {
            flags[i].SetActive(false);
        }
    }
}
