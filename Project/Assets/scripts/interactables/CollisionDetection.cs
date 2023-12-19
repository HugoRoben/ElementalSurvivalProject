// script that manages the collisions for the bullets the player shoots

using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public int waterAttackDamage = 20;
    public int airAttackDamage = 5;
    public int earthAttackDamage = 40;
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("EnemyFire"))
        {
            // get the healthmanager component of the enemy the bullet collided with
            HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();

            if (healthManager != null)
            {
                // find inventory gameobject to see which attack is selected
                var inventoryUI = FindObjectOfType<InventoryUI>();
                // check which attack is performed
                if (inventoryUI.selectedItemIndex == 0) healthManager.TakeDamage(waterAttackDamage);
                if (inventoryUI.selectedItemIndex == 1) 
                {
                    // only call takedamage if player not already dead
                    if (healthManager.healthAmount > 5)
                    {
                        healthManager.TakeDamage(airAttackDamage);
                    }
                }
                if (inventoryUI.selectedItemIndex == 2) healthManager.TakeDamage(earthAttackDamage);
                // Destroy bullet after collision
                Destroy(gameObject);
            }

        }
        if (collision.gameObject.CompareTag("wall")) Destroy(gameObject);
    }
}
