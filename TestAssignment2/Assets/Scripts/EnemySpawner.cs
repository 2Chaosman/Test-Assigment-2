using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] allSpawnPoints;
    public GameObject enemyPrefab;

    private int enemiesToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        enemiesToSpawn = Random.Range(1, allSpawnPoints.Length);
        Debug.Log(enemiesToSpawn);

        while(enemiesToSpawn > 0)
        {
            Instantiate(enemyPrefab, allSpawnPoints[Random.Range(0, allSpawnPoints.Length)].transform.position, Quaternion.identity);
            enemiesToSpawn--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
