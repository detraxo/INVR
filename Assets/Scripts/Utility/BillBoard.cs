using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BillboardSystem
{
    public class BillBoard : MonoBehaviour
    {
        public bool Y = true;
        void Start()
        {
            BillboardManager.Instance.AddToList(this);
        }
        void OnDisable()
        {
            BillboardManager.Instance.RemoveFromList(this);
        }
    }
}