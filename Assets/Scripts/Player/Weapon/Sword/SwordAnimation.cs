using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimation : MonoBehaviour
{
    public PlayerControls PlayerControls;

    private InputManagers inputManagers;
    private Animator animator;

    private void Awake()
    {
        inputManagers = new InputManagers();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        inputManagers.Player.Attack.started += _ => Attack();
    }

    private void OnEnable()
    {
        inputManagers.Enable();
    }

    private void Attack()
    {
        animator.SetTrigger("attack");

    }

    private void Update()
    {
        AnimationMove();
    }

    private void AnimationMove()
    {
        animator.SetFloat("speed", PlayerControls.Movement.sqrMagnitude);

        
            animator.SetFloat("xMove", PlayerControls.TurnMovement.x);
            animator.SetFloat("yMove", PlayerControls.TurnMovement.y);
        

    }
}
