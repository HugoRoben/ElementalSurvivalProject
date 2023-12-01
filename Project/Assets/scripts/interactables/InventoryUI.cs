using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;

    public int selectedItemIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        // Debug.Log("Slot length: " + slots.Length);
        selectedItemIndex = 0;
        UpdateItemSelectionUI();
    }

    void Update()
    {
        HandleItemScrolling();
    }

    void UpdateUI()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            slots[i + 1].AddItem(inventory.items[i]);
        }

        UpdateItemSelectionUI();
    }

    void HandleItemScrolling()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            // Increment or decrement the selected item index based on the scroll direction
            selectedItemIndex += (scroll > 0) ? 1 : -1;

            // Ensure the index stays within the bounds of the inventory items
            selectedItemIndex = Mathf.Clamp(selectedItemIndex, 0, inventory.items.Count);

            // Update the UI to reflect the selected item
            UpdateItemSelectionUI();
        }
        // Debug.Log("index:" + selectedItemIndex);
    }

    void UpdateItemSelectionUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            bool isSelected = (i == selectedItemIndex);
            slots[i].SetSelected(isSelected);
        }
    }
}
