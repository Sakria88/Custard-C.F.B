using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoFrameCheck : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {

        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video has finished playing!");

        if (SceneManager.GetActiveScene().name == "2nd cutscene")
        {
            SceneManager.LoadSceneAsync("first level");
        }

        else if (SceneManager.GetActiveScene().name == "3rd cutscene")
        {
            SceneManager.LoadSceneAsync("Second level");
        }

        else if (SceneManager.GetActiveScene().name == "MiniBCutscene")
        {
            Debug.Log("Loading: Mini Boss");
            SceneManager.LoadSceneAsync("Mini Boss");
        }

        else if (SceneManager.GetActiveScene().name == "4th cutscene")
        {
            SceneManager.LoadSceneAsync("Last cutscene");
        }

        else
        {
            SceneManager.LoadSceneAsync("first level");
        }
    }
}