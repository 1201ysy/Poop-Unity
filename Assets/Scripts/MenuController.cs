using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKey)
        {
            Play();
        }

    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");

    }

}
