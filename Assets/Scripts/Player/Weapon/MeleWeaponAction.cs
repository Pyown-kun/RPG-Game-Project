using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleWeaponAction : MonoBehaviour
{
    public SwordScript Sword;
    private float meledamage;

    private void Start()
    {
        meledamage = Sword.Damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(meledamage);
        }
    }
}
