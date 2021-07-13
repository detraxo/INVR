using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Button : MonoBehaviour
{
    public int GoToIndex = 0;
    Vector3 originalScale;
    public float Scale = 1.3f;
    public float duration = 0.3f;
    public UnityEvent Event;
    void Start()
    {
        originalScale = transform.localScale;
    }
    void OnPointerEnter()
    {
        LeanTween.scale(gameObject , originalScale*Scale, duration).setEaseOutCubic();
        Debug.Log("Button");
    }
    void OnPointerExit()
    {
        LeanTween.scale(gameObject , originalScale , duration).setEaseInCubic();
    }
    void OnPointerClick()
    {
        Event.Invoke();
        //SceneManagerScript.Instance.LoadScene(GoToIndex);
    }
    public void BackFromDetailed()
    {
        SceneManagerScript.Instance.LoadScene(Player.VrMode);
    }
    public void BackFromImages()
    {
        LeanTween.move(Player.instance.gameObject , new Vector3(0f , 2.52f , -4.21f), 1f).setEaseOutCubic();
    }
}
