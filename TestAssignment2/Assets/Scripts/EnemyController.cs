using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject mainCamera;
    private EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = GameObject.Find("SpawnPoints").GetComponent<EnemySpawner>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemySpawner.enemiesToKillInt -= 1;

        Destroy(collision.gameObject);
        Destroy(gameObject);

        if (enemySpawner.enemiesToKillInt == 0)
        {
            mainCamera.GetComponent<GameManager>().GameOver();
        }
    }


}
