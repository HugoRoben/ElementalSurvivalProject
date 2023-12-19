// defines an item in game, used for picking up objects in game and placing the corresponding item in inventory

using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public void Use ()
    {
        Debug.Log("Using" + name);
    }
}
