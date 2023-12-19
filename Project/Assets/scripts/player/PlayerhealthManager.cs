// script that manages the healthsystem of the player

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerhealthManager : MonoBehaviour
{
    public float healthAmount = 100f;
    public Image healthBar;
    private void Update()
    {
        if (healthAmount <= 0)  LoadScene();
    }

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
        SceneManager.LoadScene(3);
    }
}

