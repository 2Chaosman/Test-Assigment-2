using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] allSpawnPoints;
    public GameObject enemyPrefab;

    public int enemiesToSpawn;
    public string enemiesToKillStr;
    public int enemiesToKillInt;

    void Start()
    {
        enemiesToSpawn = UnityEngine.Random.Range(1, allSpawnPoints.Length);

        enemiesToKillStr = enemiesToSpawn.ToString();
        enemiesToKillInt = Int32.Parse(enemiesToKillStr);
        
        while (enemiesToSpawn > 0)
        {
            Instantiate(enemyPrefab, allSpawnPoints[UnityEngine.Random.Range(0, allSpawnPoints.Length)].transform.position, Quaternion.identity);
            enemiesToSpawn--;
        }
    }
}
