// script that manages interactable items

using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 5f;
    public Item item;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update ()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= radius)
        {
            Inventory.instance.Add(item);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
