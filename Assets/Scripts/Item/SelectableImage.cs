using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
public class SelectableImage : MonoBehaviour
{
    public Item item;
    Vector2 originalSize;
    Vector3 InitialPos;
    public float duration = 1f; 
    public float forwardFactor = 2f;
    public AnimationCurve curve;
    void Start()
    {
        originalSize = SidePanel.instance.image.rectTransform.sizeDelta;
        InitialPos = transform.position;
    }
    public void OnPointerEnter()
    {
        if(Player.Language == "en-US")
        {
            SidePanel.instance.name.text = item.name;
            SidePanel.instance.action.text = "Tap to hear about it more";
        }
        else
        {
            SidePanel.instance.name.text = item.hindi_name;
            SidePanel.instance.action.text = "इसके बारे में अधिक सुनने के लिए टैप करें";
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
        LeanTween.move(Player.instance.gameObject , gameObject.transform.position + gameObject.transform.forward*forwardFactor , duration).setEase(curve);
        TextToSpeechAndroid.instance.Setting(Player.Language , 1f , 1f);
        if(Player.Language == "en-US")
            TextToSpeechAndroid.instance.StartSpeak(item.description);
        else
            TextToSpeechAndroid.instance.StartSpeak(item.hindi_description);
        SidePanel.instance.downAnimation();
    }
}
