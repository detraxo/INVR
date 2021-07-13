using UnityEngine;
using UnityEngine.Video;

namespace YoutubePlayer
{
    public class SimpleYoutubeVideo : MonoBehaviour
    {
        string videoUrl;
        public Transform Circle;

        async void Start()
        {
            Debug.Log("Loading video...");
            videoUrl = Player.item.videoLink;
            Debug.Log(videoUrl);
            var videoPlayer = GetComponent<VideoPlayer>();
            await videoPlayer.PlayYoutubeVideoAsync(videoUrl);
            Circle.gameObject.SetActive(false);
        }
    }
}