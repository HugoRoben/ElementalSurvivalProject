// Script that manages the healthsystem for the enemies

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
<<<<<<< HEAD
        // code for enemy dying
=======
>>>>>>> fe62b33e0b64134a2ecfd9fb2894ffbfb67925f0
        if (healthAmount <= 4)
        {
            enemyAnimator.SetTrigger("isDying");
            enemyAnimator.SetBool("isApproaching", false);
            enemyAnimator.SetBool("Idle", false);
            enemyAnimator.SetBool("isAttacking", false);
            var Spawner = FindObjectOfType<WaveSpawner>();
            Spawner.EnemiesKilled ++;
            Spawner.EnemiesTotal ++;
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
