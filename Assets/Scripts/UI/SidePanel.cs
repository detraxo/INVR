using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
public class SidePanel : MonoBehaviour
{
    [Header("Display")]
    public new TextMeshProUGUI name; 
    public TextMeshProUGUI action; 
    public Image image;

    [Header("Animation")]
    public float up = -26f;
    public float down = -100f;
    public AnimationCurve easeUp;
    public AnimationCurve easeDown;
    public float duration = .3f;
    public static SidePanel instance;
    public GameObject item;
    void Awake()
    {
        instance = this;
    }
    public void upAnimation()
    {
        item.SetActive(true);
        LeanTween.moveLocalY(item, up , duration).setEase(easeUp);
    }
    public void downAnimation()
    {
        LeanTween.moveLocalY(item, down , duration).setEase(easeDown);
    }
    void deactivate()
    {
        item.SetActive(false);
    }
}
