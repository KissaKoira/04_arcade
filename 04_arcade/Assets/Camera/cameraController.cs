using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject platformPrefab;
    public GameObject platformPrefab2;

    GameObject nextPlatform;

    public float constantSpeed = -4f;

    float platformCounter = 0;
    float random;
    float randomHeight;
    float platformRoll;

    float enemyCounter = 0;
    float random2;

    private void Start()
    {
        random = (Random.value * 5) + 1;
        random2 = (Random.value * 5) + 1;
        platformRoll = Random.value;
        randomHeight = (Random.value * 2.5f);
    }

    private void Update()
    {
        platformCounter += Time.deltaTime;

        if(platformCounter >= random)
        {
            if(platformRoll <= 0.5f)
            {
                nextPlatform = platformPrefab;
            }
            else
            {
                nextPlatform = platformPrefab2;
            }

            createPlatform();

            platformCounter = 0;
            random = (Random.value * 5) + 1;
            randomHeight = (Random.value * 2.5f);
            platformRoll = Random.value;
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
        GameObject platform = Instantiate(nextPlatform, new Vector3(16f, randomHeight, 0), Quaternion.identity);
        platform.GetComponent<Rigidbody2D>().velocity = new Vector3(constantSpeed, 0, 0);
    }

    void createEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.GetComponent<Rigidbody2D>().velocity = new Vector3(constantSpeed, 0, 0);
    }
}