using UnityEngine;
using YoutubePlayer;

class SetupCustomYoutubeDlServer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void SetUrl()
    {
        YoutubeDl.ServerUrl = "https://invr.herokuapp.com";
    }
}