using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinataAnimationController : MonoBehaviour
{
    [SerializeField] private GameObject _pinata;

    [SerializeField] private Animator _animator;

    private void Awake()
    {
        Actions.OnPlayerStateChange += PlayAttackAnimation;
    }
    public void Start()
    {
        _pinata.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Attack");
        }
    }

    void PlayAttackAnimation(StateController.playerState playerState)
    {
        if (playerState == StateController.playerState.minigame)
        {
            _pinata.SetActive(true);
            Debug.Log("появляется пиньятка :*");
        }
    }
}
