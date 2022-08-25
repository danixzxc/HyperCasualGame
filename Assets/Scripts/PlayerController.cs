using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;
using DG.Tweening;

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


    private float startTouchPositionX;
    private Vector2 currentTouchPosition;
    private Vector2 endTouchPosition;


    [SerializeField] private protected Transform playerTransform;
    [SerializeField] private protected Transform finishTransform;

    [SerializeField] private protected Animator animator;

    private float moveFactorX;

    [SerializeField] private float maxSwerveSpeed = 1f;
    [SerializeField] private float forwardSpeed = 0.02f;
    [SerializeField] private float speed = 0.5f;
    private float swerveSpeed;

    public static bool gameStarted = false;


    void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "Finish")
        {
        Debug.Log("GameOver!");
       // Animator.SetTrigger("GameEnded"); //and stop moving
        }
        if(trigger.gameObject.tag == "RedBonus")
        {

            transform.DOScale(transform.localScale * 0.9f, 1f); // вроде теперь нельзя 2 сразу съесть. мб даже и хорошо

            //transform.localScale *= 0.9f;
            trigger.gameObject.SetActive(false);
        }
        if(trigger.gameObject.tag == "GreenBonus")
        {   
            //transform.localScale *= 1.1f;
            trigger.gameObject.SetActive(false);

            transform.DOScale(transform.localScale * 1.1f, 1f) ;
        }
    }


    private void Update()
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
    }

    private void EditorSwerve()
    {

        if (Input.GetMouseButtonDown(0))
        {
            startTouchPositionX = Input.mousePosition.x;
            animator.SetBool("IsRunning", true);
        }

        if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - startTouchPositionX;
            startTouchPositionX = Input.mousePosition.x;

        }

        if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
            animator.SetBool("IsRunning", false);
        }

        swerveSpeed = moveFactorX * Time.deltaTime * speed;
        swerveSpeed = Mathf.Clamp(swerveSpeed, -maxSwerveSpeed, maxSwerveSpeed);
        if (gameStarted && animator.GetBool("IsRunning"))
        {
            transform.Translate(swerveSpeed, 0, forwardSpeed * Time.deltaTime);

            // transform.DORotate(Vector3.up * swerveSpeed * Time.deltaTime * 550f, 0.01f);

            transform.Rotate(Vector3.up * swerveSpeed * Time.deltaTime * 550f);

        }
    }

}