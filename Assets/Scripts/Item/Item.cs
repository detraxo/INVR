using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item" , menuName = "Item")]
public class Item : ScriptableObject
{
    public int id;
    public new string name;
    public string hindi_name;
    public string description;
    public string hindi_description;
    public Sprite image;
    public float imageSize;
    public string year;
    public string style;
    public string hindi_style;
    public string architect;
    public string hindi_architect;
    public string videoLink;
    public string mapLink;
    public bool NotContainImages;
}
