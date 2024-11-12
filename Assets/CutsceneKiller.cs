using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoFrameCheck : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Register the event when the video finishes playing
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video has finished playing!");

        // Check the current scene and load the next appropriate scene
        if (SceneManager.GetActiveScene().name == "2nd cutscene")
        {
            SceneManager.LoadSceneAsync("first level");
        }
        else
        {
            SceneManager.LoadSceneAsync("2nd cutscene");
        }
    }
}