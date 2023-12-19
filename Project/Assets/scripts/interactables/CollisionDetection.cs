<<<<<<< HEAD
// script that manages the collisions for the bullets the player shoots

=======
using Unity.VisualScripting;
>>>>>>> fe62b33e0b64134a2ecfd9fb2894ffbfb67925f0
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
<<<<<<< HEAD
            // get the healthmanager component of the enemy the bullet collided with
=======
>>>>>>> fe62b33e0b64134a2ecfd9fb2894ffbfb67925f0
            HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();

            if (healthManager != null)
            {
<<<<<<< HEAD
                // find inventory gameobject to see which attack is selected
                var inventoryUI = FindObjectOfType<InventoryUI>();
                // check which attack is performed
=======
                var inventoryUI = FindObjectOfType<InventoryUI>();

>>>>>>> fe62b33e0b64134a2ecfd9fb2894ffbfb67925f0
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
