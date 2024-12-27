using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject Sword;
    public GameObject MagicWand;

    private int selectedWeapon;
    WeaponSwitch weaponSwitch;

    private void Start()
    {
        weaponSwitch = WeaponSwitch.Sword;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (selectedWeapon == 0)
            {
                weaponSwitch = WeaponSwitch.MagicWand;
            }
            else if (selectedWeapon == 1)
            {
                weaponSwitch = WeaponSwitch.Sword;
            }
        }

        switch (weaponSwitch)
        {
            case WeaponSwitch.Sword:
                PickUpSword();
                break;
            case WeaponSwitch.MagicWand:
                PickUpMagicWand();
                break;
        }
    }

    private void PickUpSword()
    {
        selectedWeapon = 0;
        Sword.SetActive(true);
        MagicWand.SetActive(false);
        Debug.Log("Pick Up Sword");
    }
    
    private void PickUpMagicWand()
    {
        selectedWeapon = 1;
        Sword.SetActive(false);
        MagicWand.SetActive(true);
        Debug.Log("Pick Up Magic Wand");
    }

    private enum WeaponSwitch
    {
        Sword,
        MagicWand
    }
}
