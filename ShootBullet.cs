using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab of the bullet
    public Transform firePoint; // Point where the bullet will be spawned
    public float bulletSpeed = 10f; // Speed of the bullet
    // public float bulletTorque = 5f;
    // public float upwardForce = 5f;

    // Update is called once per frame

    public void Shoot()
    {
        // Instantiate a new bullet at the firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component of the bullet
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Check if the bullet's Rigidbody component exists
        if (bulletRb != null)
        {
            // Apply velocity to the bullet in the forward direction
            bulletRb.velocity = firePoint.forward * bulletSpeed;
            // firePoint.up determines that the torque is applied on the upper exis of the bullet
            // bulletRb.AddTorque(firePoint.up * bulletTorque);

            // bulletRb.AddForce(firePoint.up * upwardForce, ForceMode.Impulse);
        }
    }
}
