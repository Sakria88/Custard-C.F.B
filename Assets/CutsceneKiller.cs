using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoFrameCheck : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Update()
    {
        // Check if the current frame is the last frame of the video
        if (videoPlayer.frame >= (long)(videoPlayer.frameCount - 1))
        {
            Debug.Log("Video has finished playing!");
            SceneManager.LoadSceneAsync("2nd cutscene");

        }
    }
}