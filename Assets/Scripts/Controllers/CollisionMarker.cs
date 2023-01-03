using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CollisionMarker : MonoBehaviour
{
    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Finish")
        {
            trigger.gameObject.SetActive(false);
            Actions.OnPlayerStateChange(StateController.playerState.minigame);
        }

        if (trigger.gameObject.tag == "RedBonus")
        {
            transform.DOScale(transform.localScale * 0.9f, 1f); // вроде теперь нельзя 2 сразу съесть. мб даже и хорошо
            trigger.gameObject.SetActive(false);
        }

        if (trigger.gameObject.tag == "GreenBonus")
        {
            trigger.gameObject.SetActive(false);
            transform.DOScale(transform.localScale * 1.1f, 1f) ;
        }

        if (trigger.gameObject.tag == "Crystal")

        {
            trigger.gameObject.SetActive(false);
            GemsController.UpdateMoneyCount(1);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
            GemsController.UpdateMoneyCount(15);
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerPrefs.SetFloat("Size", 1f);
            PlayerPrefs.Save();
        }    
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.SetFloat("Speed", 1.5f);
            PlayerPrefs.Save();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayerPrefs.SetInt("SizeLevel", 1);
            PlayerPrefs.Save();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.SetInt("SpeedLevel", 1);
            PlayerPrefs.Save();
        }
    }
}
