using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CollisionMarker : MonoBehaviour
{
    PlayerController playerController;
    MainMenu mainMenu;

   // [SerializeField] private TextMeshPro _text;

    private void Start()
    {
        playerController = new PlayerController(this.transform, new Rigidbody()); // переписать
        mainMenu = new MainMenu();
    }

    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Finish")
        {
            trigger.gameObject.SetActive(false);
            Actions.OnPlayerStateChange(StateController.playerState.minigame);
            Debug.Log("запускаю пиньятку o_O");
            
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
            PlayerController.CountMoney();
            Debug.Log(PlayerPrefs.GetInt("money").ToString());
            // mainMenu.text.SetText(PlayerPrefs.GetInt("money").ToString());
        }
    }
}
