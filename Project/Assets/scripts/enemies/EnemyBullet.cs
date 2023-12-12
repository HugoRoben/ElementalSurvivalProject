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
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("EnemyFire")
            || collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }
}
// twee soorten zuko, 1 snel, 1 die schiet