using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Unpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Levelselect");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
