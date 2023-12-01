using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    // public Image Healthbar;
    public float healthAmount = 60f;

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        if (healthAmount <= 10)
        {
            Destroy(gameObject);
            var Spawner = FindObjectOfType<WaveSpawner>();
            Spawner.EnemiesKilled ++;
        }
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
    }
}
