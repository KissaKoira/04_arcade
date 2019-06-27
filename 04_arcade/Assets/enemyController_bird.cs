using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController_bird : MonoBehaviour
{
    public GameObject bulletPrefab;
    float health = 10f;
    float shotCounter;
    float shotInterval = 1.5f;
    float constantSpeed = -6f;

    private void Start()
    {
        shotCounter = shotInterval;
        GetComponent<Rigidbody2D>().velocity = new Vector3(constantSpeed, 0, 0);
    }

    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        //fixes a bug where the bullet cannot be seen ingame due to large negative z axis.
        bullet.transform.position = new Vector3(bullet.transform.position.x, bullet.transform.position.y, 0);

        bullet.transform.Rotate(0f, 0f, 90f);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(constantSpeed, -4f, 0);
    }

    void Update()
    {
        if (shotCounter <= 0)
        {
            Shoot();
            shotCounter = shotInterval;
        }

        if (shotCounter > 0)
        {
            shotCounter -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 10f;
        }
    }
}
