using Enemies;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    private FirstPersonController _player;
    private EnemyHealth _health;
    private NavMeshAgent _agent;
    private const string PLAYER_STRING = "Player";
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _player = FindFirstObjectByType<FirstPersonController>();
    }

    private void Update()
    {
        if (!_player) return;
        
        _agent.SetDestination(_player.transform.position);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            _health = GetComponent<EnemyHealth>();
            _health.SelfDestruct();
        }
    }
}
