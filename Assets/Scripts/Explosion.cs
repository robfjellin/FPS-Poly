using System;
using Player;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float radius = 1.5f;
    
    private const string PLAYER_TAG = "Player";
    private const int DAMAGE_AMOUNT = 2;

    private void Start()
    {
        Explode();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Explode()
    {
        var hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (!hitCollider.CompareTag(PLAYER_TAG)) continue;
            
            var playerHealth = hitCollider.GetComponent<PlayerHealth>();
            
            if (!playerHealth) continue;
            
            playerHealth.TakeDamage(DAMAGE_AMOUNT);
            break;
        }
    }
}
