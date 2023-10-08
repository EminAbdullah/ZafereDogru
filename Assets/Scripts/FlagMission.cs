using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagMission : MonoBehaviour
{
    public GameObject nextTarget;
    public GameObject missionObject;

    private GameObject flag;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (Input.GetKey(KeyCode.E))
            {
                RandomFlag.instance.CloseAllFlags();
                RandomFlag.instance.flagCount++;
                ChangeFlag();
                flag.gameObject.SetActive(true);
                RotateTowards.instance.target = flag;

            }

        }
    }

    public void ChangeFlag()
    {
       flag = RandomFlag.instance.flags[Random.Range(0, RandomFlag.instance.flags.Length)].gameObject;
        if (flag.gameObject == this.gameObject)
        {
            ChangeFlag();
        }
       
    }

}
