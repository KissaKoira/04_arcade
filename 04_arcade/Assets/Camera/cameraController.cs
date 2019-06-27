using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject platformPrefab;
    public GameObject platformPrefab2;

    GameObject nextEnemy;
    GameObject nextPlatform;

    public float constantSpeed = -4f;

    float platformCounter = 0;
    float random;
    float randomHeight;
    float platformRoll;

    float enemyCounter = 0;
    float random2;
    float enemyRoll;

    private void Start()
    {
        random = (Random.value * 3) + 2;
        random2 = (Random.value * 3) + 2;
        platformCounter = random;
        enemyCounter = random2;
        enemyRoll = Random.value;
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
            if (enemyRoll <= 0.5f)
            {
                nextEnemy = enemyPrefab;
            }
            else
            {
                nextEnemy = enemyPrefab2;
            }

            createEnemy();

            enemyCounter = 0;
            random2 = (Random.value * 5) + 1;
            enemyRoll = Random.value;
        }
    }

    void createPlatform()
    {
        GameObject platform = Instantiate(nextPlatform, new Vector3(16f, randomHeight, 0), Quaternion.identity);
        platform.GetComponent<Rigidbody2D>().velocity = new Vector3(constantSpeed, 0, 0);
    }

    void createEnemy()
    {
        GameObject enemy = Instantiate(nextEnemy);

        if(nextEnemy == enemyPrefab)
        {
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector3(constantSpeed, 0, 0);
        }
        else
        {
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector3(constantSpeed - 2f, 0, 0);
        }
    }
}