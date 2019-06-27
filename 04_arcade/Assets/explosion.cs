using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    float counter = 0;

    void Update()
    {
        counter += Time.deltaTime;
        if(counter >= 0.3f)
        {
            Destroy(gameObject);
        }
    }
}
