using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1f;
    public Transform player;
    public Item item;

    void Update ()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= radius)
        {
            Inventory.instance.Add(item);
            // Debug.Log(gameObject.name);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
