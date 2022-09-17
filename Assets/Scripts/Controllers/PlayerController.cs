using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController// : MainMenu
{
    private float _startTouchPositionX;

    private Transform _playerTransform;


    private float _moveFactorX;

    private float _maxSwerveSpeed = 1f;
    private float _forwardSpeed = 1.5f;
    private float _speed = 0.5f;
    private float _swerveSpeed;

    private bool _gameStarted = false;
    private bool _isRunning = false;

    public PlayerController(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    public void Start()
    {
         Actions.OnGameStateChange += GameStarted;
    }

    private void GameStarted(StateController.gameState gameState)
    {
        if (gameState == StateController.gameState.game)
            _gameStarted = true;
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

            _playerTransform.DOScale(_playerTransform.localScale * 0.9f, 1f); // вроде теперь нельзя 2 сразу съесть. мб даже и хорошо

            trigger.gameObject.SetActive(false);
        }
        if(trigger.gameObject.tag == "GreenBonus")
        {   
            trigger.gameObject.SetActive(false);

            _playerTransform.DOScale(_playerTransform.localScale * 1.1f, 1f) ;
        }
    }


    public  void Update()
    {
        if (_gameStarted)

            if (UnityEngine.Application.isEditor)
                Swerve(EditorInput());
            else
                Swerve(MobileInput());

        //if (Mathf.Abs(transform.rotation.y) > 70)
        //    transform.DORotate(new Vector3(0, 0, 0), 0.5f); //почему не робит?
    
}

    private float MobileInput()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _startTouchPositionX = Input.GetTouch(0).position.x;
            Actions.OnPlayerStateChange(StateController.playerState.running);
        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            _moveFactorX = Input.GetTouch(0).position.x - _startTouchPositionX;
            _startTouchPositionX = Input.GetTouch(0).position.x;          

        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _moveFactorX = 0f; 
            Actions.OnPlayerStateChange(StateController.playerState.idle);

        }

        _swerveSpeed = _moveFactorX * Time.deltaTime * _speed;
        _swerveSpeed = Mathf.Clamp(_swerveSpeed, -_maxSwerveSpeed, _maxSwerveSpeed);

        return _swerveSpeed;
    }

    private float EditorInput()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _startTouchPositionX = Input.mousePosition.x;
            Actions.OnPlayerStateChange(StateController.playerState.running);
            _isRunning = true;
        }

        if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _startTouchPositionX;
            _startTouchPositionX = Input.mousePosition.x;

        }

        if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
            Actions.OnPlayerStateChange(StateController.playerState.idle);
            _isRunning = false;
        }

        _swerveSpeed = _moveFactorX * Time.deltaTime * _speed;
        _swerveSpeed = Mathf.Clamp(_swerveSpeed, -_maxSwerveSpeed, _maxSwerveSpeed);

        return _swerveSpeed;
    }

    private void Swerve(float swerveSpeed)
    {
        if (_isRunning)
        {
            _playerTransform.Translate(swerveSpeed, 0, _forwardSpeed * Time.deltaTime);
            _playerTransform.Rotate(Vector3.up * swerveSpeed * Time.deltaTime * 2500f);
        }
    }
}