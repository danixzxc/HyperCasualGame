using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.WSA;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController
{
    public StateMachine movementSM;
    public RunningState running;
    public MinigameState minigame;
    public MenuState menu;

    private float _startTouchPositionX;

    private Transform _playerTransform;

    private Rigidbody _playerRigidbody;

    private float _moveFactorX;

    public float maxSwerveSpeed = 1f;
    public float speed = 0.5f;


    private float _forwardSpeed = 1.5f;
    private float _swerveSpeed;

    private bool _gameStarted = false;
    private bool _isRunning = false;

    private int _money = 100;
    //public PlayerController(Transform playerTransform)
    // {
    //    _playerTransform = playerTransform;
    // }

    public PlayerController(Transform playerTransform, Rigidbody playerRigidbody)
     {
        _playerRigidbody = playerRigidbody; 
        _playerTransform = playerTransform;
    }

    public void Start()
    {
        Actions.OnGameStateChange += GameStarted;


        movementSM = new StateMachine();

        running = new RunningState(this, movementSM);
        minigame = new MinigameState(this, movementSM);
        menu = new MenuState(this, movementSM);

        movementSM.Initialize(menu);
    }

    public void Update()
    {
        movementSM.CurrentState.HandleInput();

        movementSM.CurrentState.PhysicsUpdate();

        movementSM.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        // movementSM.CurrentState.PhysicsUpdate();
    }
    /*  public void Start()
      {
           Actions.OnGameStateChange += GameStarted;
          _money = PlayerPrefs.GetInt("money");
      }
    */
    private void GameStarted(StateController.gameState gameState)
    {
        if (gameState == StateController.gameState.game)
            _gameStarted = true;
    }

    /*public  void Update()
    {
        if (_gameStarted)

            if (UnityEngine.Application.isEditor)
                Swerve(EditorInput());
            else
                Swerve(MobileInput());

        //if (Mathf.Abs(transform.rotation.y) > 70)
         //   transform.DORotate(new Vector3(0, 0, 0), 0.5f); //почему не робит?
    
}*/

   /* private float MobileInput()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _startTouchPositionX = Input.GetTouch(0).position.x;
            _isRunning = true;
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
            _isRunning = false;

        }

        _swerveSpeed = _moveFactorX * Time.deltaTime * _speed;
        _swerveSpeed = Mathf.Clamp(_swerveSpeed, -_maxSwerveSpeed, _maxSwerveSpeed);

        return _swerveSpeed ;
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

        return _swerveSpeed ;
    }*/

    public void Swerve(float swerveSpeed)
    {
        //if (_isRunning)
        //{
            _playerTransform.Translate(swerveSpeed, 0, _forwardSpeed * Time.deltaTime);
            _playerTransform.Rotate(Vector3.up * swerveSpeed * Time.deltaTime * 2500f);
            //_playerRigidbody.MovePosition(_playerTransform.position + Vector3.forward);//(swerveSpeed, 0, _forwardSpeed * Time.deltaTime));
            //_playerRigidbody.MoveRotation(new Quaternion(0, swerveSpeed * Time.deltaTime * 2500f, 0,1));
       // }
    }

    public void CountMoney()
    {
        _money++;
        PlayerPrefs.SetInt("money", _money);
    }



}