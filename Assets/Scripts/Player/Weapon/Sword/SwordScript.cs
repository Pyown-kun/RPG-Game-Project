using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public PlayerControls PlayerControls;
    public float Damage;

    [SerializeField] private GameObject meleAttack;
    [SerializeField] private GameObject topAttackAction;
    [SerializeField] private GameObject botAttackAction;
    [SerializeField] private GameObject sideAttackAction;

    private InputManagers inputManagers;

    private void Awake()
    {
        inputManagers = new InputManagers();
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
        StartCoroutine(AttackAction());
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (PlayerControls.Movement.x > 0.1)
        {
            sideAttackAction.SetActive(true);
            topAttackAction.SetActive(false);
            botAttackAction.SetActive(false);
            sideAttackAction.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (PlayerControls.Movement.x < -0.1)
        {
            sideAttackAction.SetActive(true);
            topAttackAction.SetActive(false);
            botAttackAction.SetActive(false);
            sideAttackAction.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (PlayerControls.Movement.y > 0.1)
        {
            topAttackAction.SetActive(true);
            sideAttackAction.SetActive(false);
            botAttackAction.SetActive(false);

        }
        else if (PlayerControls.Movement.y < -0.1)
        {
            botAttackAction.SetActive(true);
            topAttackAction.SetActive(false);
            sideAttackAction.SetActive(false);
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
