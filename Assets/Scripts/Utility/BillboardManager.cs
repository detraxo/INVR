using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BillboardSystem
{
    public class BillboardManager : MonoBehaviour
    {
        public static BillboardManager Instance;
        Transform Target;
        List<BillBoard> BillBoards = new List<BillBoard>();
        void Awake()
        {
            Instance = this;
        }
        void Start()
        {
            Target = Camera.main.transform;
        }
        public void AddToList(BillBoard billBoard)
        {
            BillBoards.Add(billBoard);
        }
        public void RemoveFromList(BillBoard billBoard)
        {
            BillBoards.Remove(billBoard);
        }
        void Update()
        {
            foreach(BillBoard billBoard in BillBoards)
            {
                billBoard.transform.forward = Target.position - billBoard.transform.position;
                if(!billBoard.Y)
                {
                    Vector3 e = billBoard.transform.forward;
                    e.y = 0;
                    if(e != Vector3.zero)
                    billBoard.transform.forward = e;
                }
            }
        }
    }
}