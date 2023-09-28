using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    private float xPosRange = 13;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 3.0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomEnemy()
    {
        float randXPos = Random.Range(-xPosRange, xPosRange);
        int EnemyPrefabIndex = Random.Range(0, EnemyPrefabs.Length);
        Vector3 randPos = new Vector3(randXPos, 7, 21);
        Instantiate(EnemyPrefabs[EnemyPrefabIndex], randPos, EnemyPrefabs[EnemyPrefabIndex].transform.rotation);
    }
}
