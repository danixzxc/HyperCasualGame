using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CollisionMarker : MonoBehaviour
{
    PlayerController playerController;

    [SerializeField] private TextMeshPro _text;

    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Finish")
        {
            Debug.Log("GameOver!");

            Actions.OnPlayerStateChange(StateController.playerState.attack);
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
            playerController.CountMoney();
            _text.SetText(PlayerPrefs.GetInt("money").ToString());

            trigger.gameObject.SetActive(false);
        }
    }
}
