using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync("First cutscene");
    }

    public void LevelSelect()
    {
        SceneManager.LoadSceneAsync("Levelselect");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
