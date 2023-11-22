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
    float spawnRange = 10;
    // public List<GameObject> CurrentMonsters;
    public int EnemiesKilled = 0;

    void Start()
    {
        SpawnWave();
    }

    void Update()
    {
        Debug.Log("Size:" +  Waves[CurrentWave].GetMonsterSpawnList().Length);
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
            Debug.Log("Hij spawnt iets");
            // CurrentMonsters.Add(NewSpawn);

            // EnemyAi monster = NewSpawn.GetComponent<EnemyAi>();

            // monster.SetSpawner(this);
        }
    }

    // Vector3 FindSpawnLoc()
    // {
    //     Vector3 SpawnPos;

    //     float xLoc = Random.Range(-spawnRange, spawnRange) + transform.position.x;
    //     float zLoc = Random.Range(-spawnRange, spawnRange) + transform.position.z;
    //     float yLoc = transform.position.y;

    //     SpawnPos = new Vector3(xLoc, yLoc, zLoc);

    //     if (Physics.Raycast(SpawnPos, Vector3.down, 5))
    //     {
    //         return SpawnPos;
    //     }
    //     else
    //     {
    //         return FindSpawnLoc();
    //     }
    // }
    Vector3 FindSpawnLoc(int maxAttempts = 10)
    {
        if (maxAttempts <= 0)
        {
            // Return a default position if the maximum attempts are reached
            return transform.position;
        }

        Vector3 SpawnPos;

        float xLoc = Random.Range(-spawnRange, spawnRange) + transform.position.x;
        float zLoc = Random.Range(-spawnRange, spawnRange) + transform.position.z;
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
