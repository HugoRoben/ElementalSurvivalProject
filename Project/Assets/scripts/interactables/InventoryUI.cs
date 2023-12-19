// Script that manages the canvas with the inventory UI

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class InventoryUI : MonoBehaviour
{
    // Reference to the parent object containing inventory slots
    public Transform itemsParent;

    // Reference to the Inventory script
    Inventory inventory;

    // Array to store references to individual inventory slots
    InventorySlot[] slots;

    // Index of the currently selected item in the inventory
    public int selectedItemIndex = 0;

<<<<<<< HEAD
    // UI elements for displaying player health, enemies killed, and round number
    public TextMeshProUGUI health;
    public TextMeshProUGUI enemiesKilled;
    public TextMeshProUGUI roundNumber;

    // References to external scripts for updating UI elements
    public PlayerhealthManager playerhealthManager;
    public WaveSpawner waveSpawner;

=======
>>>>>>> fe62b33e0b64134a2ecfd9fb2894ffbfb67925f0
    void Start()
    {
        // Get the Inventory instance and subscribe to the item changed callback
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        // Get references to inventory slots
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
<<<<<<< HEAD

        // Set the initial selected item index and update the UI
=======
>>>>>>> fe62b33e0b64134a2ecfd9fb2894ffbfb67925f0
        selectedItemIndex = 0;
        UpdateItemSelectionUI();
    }

<<<<<<< HEAD
    void Update()
    {
        // Retrieve the current wave number and update roundnumber UI
=======
    public TextMeshProUGUI  health;
    public TextMeshProUGUI  enemiesKilled;
    public TextMeshProUGUI roundNumber;
    public PlayerhealthManager playerhealthManager;
    public WaveSpawner waveSpawner;

    void Update()
    {
>>>>>>> fe62b33e0b64134a2ecfd9fb2894ffbfb67925f0
        int ThisWave = PlayerPrefs.GetInt("CurrentWave", 0) + 1;
        HandleItemScrolling();
        // update the healthamount and total kills in ui
        health.text = playerhealthManager.healthAmount.ToString();
        enemiesKilled.text = waveSpawner.EnemiesTotal.ToString();
        roundNumber.text = ThisWave.ToString();
    }

    // method to update UI when inventory items change
    void UpdateUI()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            // Add items to corresponding slots in the UI
            slots[i + 1].AddItem(inventory.items[i]);
        }

        // Update the selected item UI
        UpdateItemSelectionUI();
    }

    // function to handle scrolling through inventory items
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

    // Method to update the UI to reflect the selected item
    void UpdateItemSelectionUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            // Set the selected state for each inventory slot based on the index
            bool isSelected = (i == selectedItemIndex);
            slots[i].SetSelected(isSelected);
        }
    }
}