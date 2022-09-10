using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController // : MonoBehaviour
{


    private float startTouchPositionX;


    private Transform playerTransform;
    private Rigidbody playerRigidbody;


    private float moveFactorX;

    private float maxSwerveSpeed = 1f;
    private float forwardSpeed = 1.5f;
    private float speed = 0.5f;
    private float swerveSpeed;

    public static bool gameStarted = false;

    public PlayerController(Transform playerTransform, Rigidbody playerRigidbody)
    {
        this.playerTransform = playerTransform;
        this.playerRigidbody = playerRigidbody;
    }

    public void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "Finish")
        {
        Debug.Log("GameOver!");
       // Animator.SetTrigger("GameEnded"); //and stop moving
        }
        if(trigger.gameObject.tag == "RedBonus")
        {

            playerTransform.DOScale(playerTransform.localScale * 0.9f, 1f); // вроде теперь нельзя 2 сразу съесть. мб даже и хорошо

            trigger.gameObject.SetActive(false);
        }
        if(trigger.gameObject.tag == "GreenBonus")
        {   
            trigger.gameObject.SetActive(false);

            playerTransform.DOScale(playerTransform.localScale * 1.1f, 1f) ;
        }
    }


    public  void Update()
    {

        if (UnityEngine.Application.isEditor)
            EditorSwerve();
        else
            Swerve();

        //if (Mathf.Abs(transform.rotation.y) > 70)
        //    transform.DORotate(new Vector3(0, 0, 0), 0.5f); //почему не робит?
    
}

    private void Swerve()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPositionX = Input.GetTouch(0).position.x;
        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            moveFactorX = Input.GetTouch(0).position.x - startTouchPositionX;
            startTouchPositionX = Input.GetTouch(0).position.x;          

        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            moveFactorX = 0f;           

        }
        
        swerveSpeed = moveFactorX * Time.deltaTime * speed;
        swerveSpeed = Mathf.Clamp(swerveSpeed, -maxSwerveSpeed, maxSwerveSpeed);
       // if(gameStarted)
            playerTransform.Translate(swerveSpeed, 0, forwardSpeed * Time.deltaTime);
    }

    private void EditorSwerve()
    {

        if (Input.GetMouseButtonDown(0))
        {
            startTouchPositionX = Input.mousePosition.x;
            Actions.OnStateChange(true);
        }

        if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - startTouchPositionX;
            startTouchPositionX = Input.mousePosition.x;


            swerveSpeed = moveFactorX * Time.deltaTime * speed;
            swerveSpeed = Mathf.Clamp(swerveSpeed, -maxSwerveSpeed, maxSwerveSpeed);
            playerTransform.Translate(swerveSpeed, 0, forwardSpeed * Time.deltaTime);
            //playerTransform.Rotate(Vector3.up * swerveSpeed * Time.deltaTime * 850f); //vector3.up????????????
        }

        if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
            Actions.OnStateChange(false);
        }

    }

    public void Start()
    {
        playerRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
    }
}