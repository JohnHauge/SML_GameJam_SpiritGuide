using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RtoRestartScene : MonoBehaviour
{
    //private Scene currentScene;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetCurrentScene();
        }
    }

    public static void resetCurrentScene()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name.ToString());
    }
}


