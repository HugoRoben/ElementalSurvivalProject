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

    [SerializeField] WaveContent[] Waves;

    public InputManager inputManager;

    int CurrentWave = 0;
    public float spawnRange = 5;
    // public List<GameObject> CurrentMonsters;
    public int EnemiesKilled = 0;

    // public Transform waterSpawner;
    // public GameObject waterPerk;

    void Start()
    {
        SpawnWave();
    }

    void Update()
    {
        if (EnemiesKilled >= Waves[CurrentWave].GetMonsterSpawnList().Length)
        {
            EnemiesKilled = 0;
            CurrentWave ++;
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < Waves[CurrentWave].GetMonsterSpawnList().Length; i++)
        {
            Instantiate(Waves[CurrentWave].GetMonsterSpawnList()[i], FindSpawnLoc(), Quaternion.identity);

            // if (i == 1)
            // {
            //     Instantiate(waterPerk, waterSpawner.position, waterSpawner.rotation);
            // }
        }

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
        // Debug.Log("INDEX: " + randomIndex);
        // Random.Range(-spawnRange, spawnRange) + 
        float xLoc = spawnPoints[randomIndex].position.x;
        float zLoc = spawnPoints[randomIndex].position.z;
        float yLoc = transform.position.y;

        SpawnPos = new Vector3(xLoc, yLoc, zLoc);

        // Use Physics.Raycast to check if the position is valid
        if (Physics.Raycast(SpawnPos, Vector3.down, 5))
        {
            return SpawnPos;
        }
        else
        {
            // Recursive call with reduced maxAttempts
            return FindSpawnLoc(maxAttempts - 1);
        }
    }
}
