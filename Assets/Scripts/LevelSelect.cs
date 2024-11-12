using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void One()
    {
        SceneManager.LoadSceneAsync("first level");
    }

    public void Two()
    {
        SceneManager.LoadSceneAsync("second level");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
