using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private InputManagers inputManagers;
    private Rigidbody2D rb;
    private Vector2 movement;

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
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void PlayerInput()
    {
        movement = inputManagers.Player.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * moveSpeed);
    }

}
