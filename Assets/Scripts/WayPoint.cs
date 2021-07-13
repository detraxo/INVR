using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public Vector3 HideOffset = new Vector3(0,-4,0);
    public bool isShown = true;
    Vector3 InitialPos;
    public float duration = 1f; 
    public AnimationCurve curve;
    public Sprite image; 
    Vector2 originalSize;
    public GameObject[] Sprites;
    void Start()
    {
        originalSize = SidePanel.instance.image.rectTransform.sizeDelta;
        WayPointManager.Instance.AddToList(this);
        InitialPos = transform.position;
    }
    void OnDisable()
    {
        WayPointManager.Instance.RemoveFromList(this);
    }
    public void OnPointerClick()
    {
        LeanTween.move(Player.instance.gameObject , gameObject.transform.position + new Vector3(0f , 1.5f , 0f) , duration).setEase(curve);
    }
    public void OnPointerEnter()
    {
        if(Player.Language == "en-US")
        {
            SidePanel.instance.name.text = "Waypoint";
            SidePanel.instance.action.text= "Tap to go to waypoint";
        }
        else
        {
            SidePanel.instance.name.text = "वेपॉइंट";
            SidePanel.instance.action.text= "वेपॉइंट पर जाने के लिए टैप करें";
        }
        SidePanel.instance.image.rectTransform.sizeDelta = originalSize/4f;
        SidePanel.instance.image.sprite = image;
        SidePanel.instance.upAnimation();
    }
    public void OnPointerExit()
    {
        SidePanel.instance.downAnimation();
    }
    public void Show(bool val)
    {
        foreach(GameObject gameObject in Sprites)
        {
            if(val)
            {
                if(!isShown)
                {
                    transform.LeanMove(InitialPos,.5f).setEaseInOutExpo();
                    isShown = true;
                }
            }
            else
            {
                if(isShown)
                {
                    transform.LeanMove(InitialPos+HideOffset,.5f).setEaseInOutExpo();
                    isShown = false;
                }
            }
        }
    }
}
