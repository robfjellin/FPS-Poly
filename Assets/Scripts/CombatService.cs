using System;
using UnityEngine;

public class CombatService : MonoBehaviour
{
    public event EventHandler OnDeath;

    public void EnemyDeathEvent()
    {
        OnDeath?.Invoke(this, EventArgs.Empty);
    }
}
