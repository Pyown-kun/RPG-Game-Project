using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject meleAttack;
    [SerializeField] private GameObject topAttackAction;
    [SerializeField] private GameObject botAttackAction;
    [SerializeField] private GameObject sideAttackAction;

    private InputManagers inputManagers;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    private void Awake()
    {
        inputManagers = new InputManagers();
        rb = GetComponent<Rigidbody2D>();
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

    private void Update()
    {
        PlayerInput();
        AnimationMove();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void PlayerInput()
    {
        movement = inputManagers.Player.Move.ReadValue<Vector2>();
    }

    private void Attack()
    {
        animator.SetTrigger("attack");

        StartCoroutine(AttackAction());
    }


    private void Move()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * moveSpeed);

        if (movement.x > 0.1)
        {
            sideAttackAction.SetActive(true);
            topAttackAction.SetActive(false);
            botAttackAction.SetActive(false);
            sideAttackAction.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movement.x < -0.1)
        {
            sideAttackAction.SetActive(true);
            topAttackAction.SetActive(false);
            botAttackAction.SetActive(false);
            sideAttackAction.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (movement.y > 0.1)
        {
            topAttackAction.SetActive(true);
            sideAttackAction.SetActive(false);
            botAttackAction.SetActive(false);

        }
        else if (movement.y < -0.1)
        {
            botAttackAction.SetActive(true);
            topAttackAction.SetActive(false);
            sideAttackAction.SetActive(false);
        }
    }

    private void AnimationMove()
    {
        animator.SetFloat("speed", movement.sqrMagnitude);
        
        if (movement != Vector2.zero)
        {
            animator.SetFloat("xMove", movement.x);
            animator.SetFloat("yMove", movement.y);
        }

    }

    private IEnumerator AttackAction()
    {
        yield return new WaitForSeconds(0.4f);
        meleAttack.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        meleAttack.SetActive(false);
    }
}
