// script that describes the functionality of a slot in the inventory

using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }
    public void UseItem()
    {
        if (item != null) item.Use();

    }
    public void SetSelected(bool isSelected)
    {
        // change background color to yellow of selected item
        if (isSelected) transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
        else transform.GetChild(0).GetComponent<Image>().color = Color.black;
    }
}
