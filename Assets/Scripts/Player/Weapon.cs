using System;
using Cinemachine;
using Enemies;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private LayerMask interactionLayers;
    
    CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Shoot(WeaponSO weaponSo)
    {
        impulseSource.GenerateImpulse();
        muzzleFlash.Play();

        RaycastHit hit;
        
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers, QueryTriggerInteraction.Ignore)) 
        {
            Instantiate(weaponSo.HitVFXPrefab, hit.point, Quaternion.identity);
            
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>(); 
            enemyHealth?.TakeDamage(weaponSo.Damage);
        }
        
    }
}
