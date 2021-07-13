using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TextSpeech;
public class SelectableItem : MonoBehaviour
{
    public Item item;
    Vector2 originalSize;
    int clickedCounter = 0;
    int counter = 0;
    void Start()
    {
        originalSize = SidePanel.instance.image.rectTransform.sizeDelta;
    }
    void Update()
    {
        if(clickedCounter >= 1 && counter*Time.deltaTime < 1f)
        {
            counter++;
            if(clickedCounter == 2)
            {
                Player.item = item;
                if(Player.Language == "hi-IN")
                {
                    Player.item.name = item.hindi_name;
                    Player.item.description = item.hindi_description;
                    Player.item.architect = item.hindi_architect;
                    Player.item.style = item.hindi_style;
                }
                SceneManagerScript.Instance.LoadScene(3);
                Player.PlayerPosition = Player.instance.transform.position;
                counter = 0;
                clickedCounter = 0;
            }
        }
        else
        {
            clickedCounter = 0;
            counter = 0;
        }
    }
    public void OnPointerEnter()
    {
        TextToSpeechAndroid.instance.Setting(Player.Language , 1f , 1f);
        //VoiceController.instance.StartSpeaking("Hello");
        if(Player.Language == "en-US")
        {
            TextToSpeechAndroid.instance.StartSpeak(item.name);
            SidePanel.instance.name.text = item.name;
            SidePanel.instance.action.text = "Double Tap to know more";
        }
        else
        {
            TextToSpeechAndroid.instance.StartSpeak(item.hindi_name);
            SidePanel.instance.name.text = item.hindi_name;
            SidePanel.instance.action.text = "अधिक जानने के लिए दो बार टैप करें";
        }
        SidePanel.instance.image.sprite = item.image;
        SidePanel.instance.image.rectTransform.sizeDelta = originalSize*item.imageSize;
        SidePanel.instance.upAnimation();
    }
    public void OnPointerExit()
    {
        SidePanel.instance.downAnimation();
    }
    void OnPointerClick()
    {
        clickedCounter++;
    }
}
