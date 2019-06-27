using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playGame : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main");
    }
}
