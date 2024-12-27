using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public Vector2 TurnMovement;
    public Vector2 Movement;

    [SerializeField] private float moveSpeed;

    private InputManagers inputManagers;
    private Rigidbody2D rb;

    private void Awake()
    {
        inputManagers = new InputManagers();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputManagers.Enable();
    }

    private void Update()
    {
        PlayerInput();
        TurnMove();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void PlayerInput()
    {
        Movement = inputManagers.Player.Move.ReadValue<Vector2>();
    }


    private void Move()
    {
        rb.MovePosition(rb.position + Movement * Time.fixedDeltaTime * moveSpeed);
    }

    private void TurnMove()
    {
        if (Movement.x == 1)
        {
            TurnMovement.x = 1;
            TurnMovement.y = 0;
        }
        else if (Movement.x == -1)
        {
            TurnMovement.x = -1;
            TurnMovement.y = 0;
        }

        if (Movement.y == 1)
        {
            TurnMovement.y = 1;
            TurnMovement.x = 0;
        }
        else if (Movement.y == -1)
        {
            TurnMovement.y = -1;
            TurnMovement.x = 0;
        }
    }
    
}
