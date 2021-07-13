using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToLink : MonoBehaviour
{
    string Link;
    void Start()
    {
        Link = Player.item.mapLink;
    }
    public void Go()
    {
        Application.OpenURL(Link);
    }
}

