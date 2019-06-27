using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController_fox : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject gunPoint;
    public GameObject gunSmokePrefab;
    GameObject gunSmoke;
    float health = 20f;
    float shotCounter;
    float shotInterval = 1.5f;

    private void Start()
    {
        shotCounter = shotInterval;
    }

    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, gunPoint.transform.position, Quaternion.identity);
        gunSmoke = (GameObject)Instantiate(gunSmokePrefab, gunPoint.transform.position, Quaternion.identity);

        //fixes a bug where the bullet cannot be seen ingame due to large negative z axis.
        bullet.transform.position = new Vector3(bullet.transform.position.x, bullet.transform.position.y, 0);
        gunSmoke.transform.position = new Vector3(gunSmoke.transform.position.x, gunSmoke.transform.position.y, 0);

        bullet.transform.Rotate(0f, 180f, 0f);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(-10f, 0, 0);
    }

    void Update()
    {
        if (shotCounter <= 0)
        {
            Destroy(gunSmoke);
            Shoot();
            shotCounter = shotInterval;
        }

        if(shotCounter > 0)
        {
            shotCounter -= Time.deltaTime;
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 10f;
        }
    }
}
