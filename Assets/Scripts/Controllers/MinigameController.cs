using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    [SerializeField] private Animator _pinataAnimator;
    [SerializeField] private Animator _playerAnimator;
    private void Attack()
    {
        _pinataAnimator.SetTrigger("Attack");
    }

    private void AttackEnd()
    {
        _playerAnimator.SetBool("Attacking", false);
    }
}
