using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 10f;

    // This function will be called from the Animation Event
    public void FireBulletFromAnimationEvent()
    {
        // Instantiate a new bullet at the firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Apply force to the bullet in the forward direction
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}