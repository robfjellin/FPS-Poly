using UnityEngine;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explodeParticles;
        
        private const int STARTING_HEALTH = 3;
        private int _currentHealth;
        private CombatService _combatService;

        private void Awake()
        {
            _currentHealth = STARTING_HEALTH;
            _combatService = FindFirstObjectByType<CombatService>();
        }

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0)
            {
                _combatService.EnemyDeathEvent();
                SelfDestruct();
            }
        }

        public void SelfDestruct()
        {
            Instantiate(explodeParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
