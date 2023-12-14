using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfWaves = 3;
    public int EnemiesPerWave = 5;
    public float timeBetweenWaves = 10f;
    public float spawnRadius = 5f;
    public float difficultyMultiplier = 1.1f;
    public float enemyLifetime = 10f;
    private float XPosRngLow = 1;
    private float XPosRngHigh = 9;
    private float YPosRngLow = 13;
    private float YPosRngHigh = 15;


    private int currentWave = 1;



    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnEnemyWaves", 0f, timeBetweenWaves);

    }


    void SpawnEnemyWaves()
    {
        SpawnEnemies(EnemiesPerWave + (currentWave - 1));

        currentWave++;


    }

    void SpawnEnemies(int count)
    {
        for(int i = 0; i < count; i++)
        {
            float randomX = Random.Range(XPosRngLow, XPosRngHigh);
            float randomY = Random.Range(YPosRngLow, YPosRngHigh);

            Vector2 randomSpawnPosition = new Vector2(randomX, randomY) + (Vector2)transform.position;

            Debug.Log(randomSpawnPosition);
            GameObject enemy = Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
        }
    }

    void AdjustDifficulty(GameObject enemy, int wave)
    {
        SpawnEnemy enemyController = enemy.GetComponent<SpawnEnemy>();

        if(enemyController != null)
        {
            
            enemyController.speed *= Mathf.Pow(difficultyMultiplier, wave - 1);
        }
    }

    IEnumerator DestroyAfterShortDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
