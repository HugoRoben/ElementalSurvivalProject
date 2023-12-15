using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float healthAmount = 100f;
    public Image healthBar;
    public Animator enemyAnimator;

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 80f;
        if (healthAmount <= 4)
        {
            enemyAnimator.SetTrigger("isDying");
            enemyAnimator.SetBool("isApproaching", false);
            enemyAnimator.SetBool("Idle", false);
            enemyAnimator.SetBool("isAttacking", false);
            var Spawner = FindObjectOfType<WaveSpawner>();
            Spawner.EnemiesKilled ++;
        }
    }
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 80f;
    }
    public void DeathAnimationEvent()
    {
        Destroy(gameObject);
    }
}
