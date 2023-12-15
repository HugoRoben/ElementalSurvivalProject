using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;

    public int selectedItemIndex = 0;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        selectedItemIndex = 0;
        UpdateItemSelectionUI();
    }

    public TextMeshProUGUI  health;
    public TextMeshProUGUI  enemiesKilled;
    public TextMeshProUGUI  enemiesTotal;
    public TextMeshProUGUI roundNumber;
    public PlayerhealthManager playerhealthManager;
    public WaveSpawner waveSpawner;

    void Update()
    {
        HandleItemScrolling();
        health.text = playerhealthManager.healthAmount.ToString();
        enemiesKilled.text = waveSpawner.EnemiesKilled.ToString();
        enemiesTotal.text = waveSpawner.Waves[waveSpawner.CurrentWave].GetMonsterSpawnList().Length.ToString();
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
