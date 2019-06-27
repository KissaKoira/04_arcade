using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if(collision.gameObject.tag == "Enemy")
        {
            GameObject.Find("Main Camera").GetComponent<shake>().CamShake();
        }
    }
}
