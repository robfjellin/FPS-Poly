using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera deathVirtualCamera;
        [SerializeField] private Transform weaponCamera;
        [SerializeField] private Image[] shieldBar;
        [SerializeField] private CombatService combatService;
        
        private const int STARTING_HEALTH = 5;
        private const int CAMERA_PRIORITY = 20;
        private const int VAMP_AMOUNT = -1;
        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = STARTING_HEALTH;
            AdjustShieldUI();
        }

        private void Start()
        {

            combatService.OnDeath += VampHealth;
        }

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            AdjustShieldUI();

            if (_currentHealth <= 0)
            {
                weaponCamera.parent = null;
                deathVirtualCamera.Priority = CAMERA_PRIORITY;
                Destroy(this.gameObject);
            }
        }

        private void AdjustShieldUI()
        {
            for (int i = 0; i < shieldBar.Length; i++)
            {
                if (i < _currentHealth)
                {
                    shieldBar[i].enabled = true;
                }
                else
                {
                    shieldBar[i].enabled = false;
                }
            }
        }

        private void VampHealth(object sender, EventArgs e)
        {
            TakeDamage(VAMP_AMOUNT);
            Debug.Log("Vamp Health");
        }
    }
}
