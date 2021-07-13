using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
public class Player : MonoBehaviour
{
    public static Player instance;
    public static Vector3 PlayerPosition = new Vector3(0f , 0f , 0f);
    public static Item item;
    public static int VrMode = 1;
    public static string Language = "en-US";
    void Awake()
    {
       instance = this; 
    }
    void Start()
    {
        if(SceneManagerScript.Instance.getSceneIndex() == 1 && PlayerPosition != new Vector3(0f,0f,0f))
            gameObject.transform.position = PlayerPosition;
    }
    public void setMuseumMode()
    {
        VrMode = 1;
    }
    public void setMapMode()
    {
        VrMode = 2;
    }
    public void changeLanguage()
    {
        Language = LocalizationSettings.SelectedLocale.ToString().Split(')')[1].Substring(2 , 5);
    }
}

