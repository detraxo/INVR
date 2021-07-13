using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DetailsInstantiator : MonoBehaviour
{
    public TextMeshPro Name;
    public TextMeshPro Year;
    public TextMeshPro Architect;
    public TextMeshPro Style;
    void Start()
    {
        Name.text = Player.item.name;
        Year.text = Player.item.year;
        Architect.text = Player.item.architect;
        Style.text = Player.item.style;
    }
}
