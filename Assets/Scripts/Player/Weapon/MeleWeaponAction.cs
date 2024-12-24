using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleWeaponAction : MonoBehaviour
{
    public WeaponDamage WeaponDamage;
    private float meledamage;

    private void Start()
    {
        meledamage = WeaponDamage.Damage;
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
