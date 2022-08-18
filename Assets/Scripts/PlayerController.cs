using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    // Rigidbody r;
    // void Start()
    // {
    //     r = GetComponent<Rigidbody>();
    //     r.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    //     r.freezeRotation = true;
    // }

void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "Finish")
        {
        Debug.Log("GameOver!");
       // Animator.SetTrigger("GameEnded"); //and stop moving
        }
        if(trigger.gameObject.tag == "RedBonus")
        {
            transform.localScale *= 0.9f;
            trigger.gameObject.SetActive(false);
        }
        if(trigger.gameObject.tag == "GreenBonus")
        {   
            transform.localScale *= 1.1f;
            trigger.gameObject.SetActive(false);
        }
    }


    private float startTouchPositionX;
    private Vector2 currentTouchPosition;
    private Vector2 endTouchPosition;


    [SerializeField] private protected Transform playerStartPosition;
    [SerializeField] private protected Transform finishPosition;

    private float moveFactorX;

    [SerializeField] private float maxSwerveSpeed = 1f;
    [SerializeField] private float forwardSpeed = 0.02f;
    [SerializeField]private float speed = 0.5f;
    private float swerveSpeed;

    public static bool gameStarted = false;
    private void Update()
    {
        Swipe();
    }

    private void Swipe()
    {
        // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        // {
        //     startTouchPosition = Input.GetTouch(0).position;
        //     if (gameOver)
        //     {
        //         //Restart current scene
        //         Scene scene = SceneManager.GetActiveScene();
        //         SceneManager.LoadScene(scene.name);
        //     }
        //     else
        //     {
        //         //Start the game
        //         gameStarted = true;
        //     }
        // }

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
        if(gameStarted)
            transform.Translate(swerveSpeed, 0, forwardSpeed * Time.deltaTime);
        if(!gameStarted)
            transform.Translate(swerveSpeed, 0, 0);
    }
    
}