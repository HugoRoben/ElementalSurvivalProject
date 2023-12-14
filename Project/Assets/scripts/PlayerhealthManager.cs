using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerhealthManager : MonoBehaviour
{
    private void Update()
    {
        if (healthAmount <= 0) LoadScene();
    }
    public float healthAmount = 100f;
    public Image healthBar;

    public void PlayerTakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}

