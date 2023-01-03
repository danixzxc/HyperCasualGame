using UnityEngine;

public class PlayerController
{
    public StateMachine movementSM;
    public RunningState running;
    public MinigameState minigame;
    public MenuState menu;

    private Transform _playerTransform;
    private Animator _playerAnimator;

    public float maxSwerveSpeed = 1f;
    public float speed = 0.5f;

    private float _forwardSpeed = 1.5f;

   
    public PlayerController(Transform playerTransform, Animator playerAnimator)
     {
        _playerAnimator = playerAnimator; 
        _playerTransform = playerTransform;
    }

    public void Start()
    {
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
    }
    public void Swerve(float swerveSpeed)
    {
        _playerTransform.Translate(swerveSpeed, 0, _forwardSpeed * Time.deltaTime);
        Quaternion rot = Quaternion.Euler(new Vector3(0,swerveSpeed * 50, 0));
        _playerTransform.Rotate(rot.eulerAngles);
    }

    public void Attack()
    {
        _playerAnimator.SetBool("Attacking", true);
    }
}