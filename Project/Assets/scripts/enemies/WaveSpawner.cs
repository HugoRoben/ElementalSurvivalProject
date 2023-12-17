using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class WaveContent
    {
        [SerializeField][NonReorderable] GameObject[] WaveSpawner;
        public GameObject[] GetMonsterSpawnList()
        {
            return WaveSpawner;
        } 
    }

    [SerializeField] public WaveContent[] Waves;

    public InputManager inputManager;

    public int CurrentWave = 0;
    public int EnemiesKilled = 0;
    public int EnemiesTotal = 0;
    

    void Start()
    {
        SpawnWave();
    }
    public InventoryUI inventoryUI;
    void Update()
    {
        PlayerPrefs.SetInt("EnemiesTotal", EnemiesTotal);
        PlayerPrefs.SetInt("CurrentWave", CurrentWave);
        if (EnemiesKilled == Waves[CurrentWave].GetMonsterSpawnList().Length)
        {
            EnemiesKilled = 0;
            CurrentWave ++;
            inventoryUI.roundNumber.text = "Round " + CurrentWave.ToString();
            Invoke(inventoryUI.roundNumber.text = "", 2);
            Invoke("SpawnWave", 3);
            if (CurrentWave == 1) spawnAirPickup();
            if (CurrentWave == 2) spawnEarthPickup();
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < Waves[CurrentWave].GetMonsterSpawnList().Length; i++)
        {
            Instantiate(Waves[CurrentWave].GetMonsterSpawnList()[i], FindSpawnLoc(), Quaternion.identity);
        }
    }

    // variables needed to spawn items to pickup new attacks in game
    public GameObject airPickUp;
    public GameObject earthPickUp;
    public Transform airPickUpTransform;
    public Transform earthPickUpTransform;
    void spawnAirPickup()
    {
        Instantiate(airPickUp, airPickUpTransform.position, airPickUpTransform.rotation);
    }
    void spawnEarthPickup()
    {
        Instantiate(earthPickUp, earthPickUpTransform.position, earthPickUpTransform.rotation);
    }

    // make a list of spawnpoints
    public Transform[] spawnPoints;
    Vector3 FindSpawnLoc(int maxAttempts = 10)
    {
        if (maxAttempts <= 0)
        {
            return transform.position;
        }

        Vector3 SpawnPos;
        int randomIndex = Random.Range(0, spawnPoints.Length);
        float xLoc = spawnPoints[randomIndex].position.x;
        float zLoc = spawnPoints[randomIndex].position.z;
        float yLoc = transform.position.y;

        SpawnPos = new Vector3(xLoc, yLoc, zLoc);

        // Use Physics.Raycast to check if the position is valid
        if (Physics.Raycast(SpawnPos, Vector3.down, 5)) return SpawnPos;
        else return FindSpawnLoc(maxAttempts - 1);
    }
}
