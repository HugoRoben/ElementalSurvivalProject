using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollision : MonoBehaviour
{
    public void HandleCollision()
    {
        var gameManager = FindObjectOfType<PlayerhealthManager>();
        gameManager.PlayerTakeDamage(5);
        Debug.Log(gameManager.healthAmount);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandleCollision();
        }
    }
}
