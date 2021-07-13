using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
public class ItemSelector : MonoBehaviour
{
    public GameObject videoButton;
    public GameObject imagesButton;
    public bool editId = false;
    public int id;
    bool isSpeaking = true;
    public GameObject speak;
    public GameObject cross;
    public Image image;
    float yRot = 0;
    Vector2 originalSize;
    void OnApplicationQuit()
    {
        TextToSpeechAndroid.instance.StopSpeak();
    }
    void Start()
    {
        if(!editId)
            id = Player.item.id;
        if(id >= 6)
        {
            id = 6;
            image.sprite = Player.item.image;
            originalSize = image.rectTransform.sizeDelta;
            image.rectTransform.sizeDelta = originalSize*Player.item.imageSize*3.1f;
        }
        SelectedItem();
        TextToSpeechAndroid.instance.Setting(Player.Language, 1f , 1f);
        TextToSpeechAndroid.instance.StartSpeak(Player.item.description);
        if(Player.item.NotContainImages)
            imagesButton.SetActive(false);
        else
            imagesButton.SetActive(true);
        if(Player.item.videoLink.Trim()== "")
            videoButton.SetActive(false);
        else
            videoButton.SetActive(true);
    }
    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(yRot , Vector3.up); 
        yRot += 0.3f;
    }
    void SelectedItem()
    {
        int i = 0;
        foreach(Transform item in transform)
        {
            if(i == id)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
            i++;
        } 
    }
    public void ToggleVoice()
    {
        if(!isSpeaking)
        {
            TextToSpeechAndroid.instance.Setting(Player.Language , 1f , 1f);
            if(Player.Language == "en-US")
                TextToSpeechAndroid.instance.StartSpeak(Player.item.description);
            else
                TextToSpeechAndroid.instance.StartSpeak(Player.item.hindi_description);
            isSpeaking = true;
            cross.SetActive(true);
            speak.SetActive(false);
        }
        else
        {
            TextToSpeechAndroid.instance.StopSpeak();
            isSpeaking = false;
            cross.SetActive(false);
            speak.SetActive(true);
        }
    }
}
