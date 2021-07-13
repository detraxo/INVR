using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRoomSelector : MonoBehaviour
{
    public int id;
    void Start()
    {
        id = Player.item.id;
        SelectedItem();
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
}
