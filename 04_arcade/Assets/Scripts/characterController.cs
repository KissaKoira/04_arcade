using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject gunSmokePrefab;
    public GameObject gunPoint;
    public Animator animator;
    public float maxSpeed;
    public float smoothing = 5;
    public float jumpForce = 0.5f;
    float jumpSpeed = 0;
    public float maxJumpSpeed;
    bool jumping = false;
    public string orientation = "Right";
    float speed = 0;
    float constantSpeed = -3f;

    bool shotCd = false;
    float shotCounter = 0;

    private void Start()
    {
    }

    private void Move(string str)
    {
        float horizontal = 0;

        switch (str)
        {
            case "Right":
                horizontal = 1;
                break;
            case "Left":
                horizontal = -1;
                break;
        }

        if(speed < maxSpeed)
        {
            speed += smoothing;
        }

        player.GetComponent<Rigidbody2D>().velocity = new Vector2((horizontal * speed * Time.fixedDeltaTime) + constantSpeed, player.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void Jump()
    {
        animator.SetBool("Jumping", true);
        jumping = true;
    }

    private void Shoot()
    {
        //animator.SetTrigger("Shoot");

        Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction;

        if(orientation == "Right")
        {
            direction = new Vector2(1f, 0f);
        }
        else
        {
            direction = new Vector2(-1f, 0f);
        }

        direction.Normalize();

        Instantiate(gunSmokePrefab, gunPoint.transform.position, Quaternion.identity);

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, myPos, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 20f;

        shotCd = true;
        shotCounter = 0.5f;
    }

    private void Flip(string str)
    {
        if (str != orientation)
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if(shotCd == true)
        {
            shotCounter -= Time.deltaTime;
        }

        if(shotCounter <= 0)
        {
            shotCd = false;
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if(Input.GetButtonDown("Fire1"))
        {
            if(shotCd == false)
            {
                Shoot();
            }
        }

        if(horizontal > 0)
        {
            Move("Right");
            Flip("Right");
            orientation = "Right";
            animator.SetBool("Idle", false);
        }
        else if (horizontal < 0)
        {
            Move("Left");
            Flip("Left");
            orientation = "Left";
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Idle", true);

            Vector3 playerVel = player.GetComponent<Rigidbody2D>().velocity;

            player.GetComponent<Rigidbody2D>().velocity = new Vector3(constantSpeed, playerVel.y, playerVel.z);
        }

        if(jumping == true)
        {
            if(jumpSpeed >= maxJumpSpeed)
            {
                jumping = false;
                jumpSpeed = 0;
            }
            else
            {
                jumpSpeed += jumpForce;

                Vector3 playerVel = player.GetComponent<Rigidbody2D>().velocity;
                player.GetComponent<Rigidbody2D>().velocity = new Vector3(playerVel.x, jumpSpeed, playerVel.z);
            }
        }

        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) < 0.1)
        {
            animator.SetBool("Jumping", false);
        }
    }
}