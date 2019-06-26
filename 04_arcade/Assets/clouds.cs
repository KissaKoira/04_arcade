using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clouds : MonoBehaviour
{
    public GameObject cam;
    Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.position;
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 0, 0);

        if (transform.position.x <= -12)
        {
            transform.position = new Vector3(12, originalPos.y, originalPos.z);
        }
    }
}
