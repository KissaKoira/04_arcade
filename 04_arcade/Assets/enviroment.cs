using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enviroment : MonoBehaviour
{
    public GameObject cam;
    Vector3 originalPos;
    float width;

    private void Start()
    {
        originalPos = transform.position;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(cam.GetComponent<cameraController>().constantSpeed, 0, 0);

        

        if(transform.position.x <= -20)
        {
            transform.position = new Vector3(transform.position.x + (width * 2), originalPos.y, originalPos.z);
        }
    }
}
