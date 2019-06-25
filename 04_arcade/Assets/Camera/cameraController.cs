using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject platformPrefab;

    float platformCounter = 0;
    float random;

    float enemyCounter = 0;
    float random2;

    private void Start()
    {
        random = (Random.value * 5) + 1;
        random2 = (Random.value * 5) + 1;
    }

    private void Update()
    {
        platformCounter += Time.deltaTime;

        if(platformCounter >= random)
        {
            createPlatform();

            platformCounter = 0;
            random = (Random.value * 5) + 1;
        }

        enemyCounter += Time.deltaTime;

        if (enemyCounter >= random2)
        {
            createEnemy();

            enemyCounter = 0;
            random2 = (Random.value * 5) + 1;
        }
    }

    void createPlatform()
    {
        GameObject platform = Instantiate(platformPrefab);
        platform.GetComponent<Rigidbody2D>().velocity = new Vector3(-3f, 0, 0);
    }

    void createEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.GetComponent<Rigidbody2D>().velocity = new Vector3(-3f, 0, 0);
    }
}