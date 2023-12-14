using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("EnemyFire"))
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
                if (inventoryUI.selectedItemIndex == 1) healthManager.TakeDamage(60);

                else healthManager.TakeDamage(20);

                Destroy(gameObject);
            }

        }
        if (collision.gameObject.CompareTag("wall")) Destroy(gameObject);
    }
}
