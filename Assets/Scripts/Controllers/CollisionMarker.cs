using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollisionMarker : MonoBehaviour
{
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
    }
}
