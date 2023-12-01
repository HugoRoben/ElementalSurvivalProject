using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("EnemyFire"))
        {
            Debug.Log("Firenemy hit");
            WalkTrigger walkTrigger = collision.gameObject.GetComponent<WalkTrigger>();
            HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();

            if (walkTrigger != null)
            {
                walkTrigger.GetHit = true;
            }
            if (healthManager != null)
            {
                var inventoryUI = FindObjectOfType<InventoryUI>();
                // check if selected attack is water, effective against fire enemy
                if (inventoryUI.selectedItemIndex == 1)
                {
                    healthManager.TakeDamage(60);
                }
                else
                {
                    healthManager.TakeDamage(20);
                }
                
                Destroy(gameObject);
                // Debug.Log("Health" + healthManager.healthAmount);
            }

        }
        if (collision.gameObject.CompareTag("EnemyWater"))
        {
            WalkTrigger walkTrigger = collision.gameObject.GetComponent<WalkTrigger>();
            HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();

            if (walkTrigger != null)
            {
                walkTrigger.GetHit = true;
            }
            if (healthManager != null)
            {
                var inventoryUI = FindObjectOfType<InventoryUI>();
                // check if selected attack is water, effective against fire enemy
                if (inventoryUI.selectedItemIndex == 0)
                {
                    healthManager.TakeDamage(60);
                }
                else
                {
                    healthManager.TakeDamage(20);
                }
                Destroy(gameObject);
            }

        }
        if (collision.gameObject.CompareTag("EnemyEarth"))
        {
            WalkTrigger walkTrigger = collision.gameObject.GetComponent<WalkTrigger>();
            HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();

            if (walkTrigger != null)
            {
                walkTrigger.GetHit = true;
            }
            if (healthManager != null)
            {
                var inventoryUI = FindObjectOfType<InventoryUI>();
                // check if selected attack is water, effective against fire enemy
                if (inventoryUI.selectedItemIndex == 2)
                {
                    healthManager.TakeDamage(60);
                }
                else
                {
                    healthManager.TakeDamage(20);
                }
                
                Destroy(gameObject);
            }

        }
        if (collision.gameObject.CompareTag("EnemyAir"))
        {
            WalkTrigger walkTrigger = collision.gameObject.GetComponent<WalkTrigger>();
            HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();

            if (walkTrigger != null)
            {
                walkTrigger.GetHit = true;
            }
            if (healthManager != null)
            {
                var inventoryUI = FindObjectOfType<InventoryUI>();
                // check if selected attack is water, effective against fire enemy
                if (inventoryUI.selectedItemIndex == 3)
                {
                    healthManager.TakeDamage(60);
                }
                else
                {
                    healthManager.TakeDamage(20);
                }
                
                Destroy(gameObject);
            }

        }    
    }
}
