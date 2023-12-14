using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        var gameManager = FindObjectOfType<PlayerhealthManager>();

        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            // Ignore the collision with the specified tag
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.PlayerTakeDamage(2);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

}