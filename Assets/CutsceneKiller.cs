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

        if (SceneManager.GetActiveScene().name == "3rd cutscene")
        {
            SceneManager.LoadSceneAsync("Second level");
        }

        else
        {
            SceneManager.LoadSceneAsync("2nd cutscene");
        }
    }
}