using System;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponPickup : Pickup
{
    [SerializeField] private WeaponSO weaponSo;

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
            activeWeapon.SwitchWeapon(weaponSo);
            Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
