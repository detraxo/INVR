using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public static WayPointManager Instance;
    List<WayPoint> WayPoints = new List<WayPoint>();
    public Transform Target;
    public float DistanceSquaredToDisable = 80;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Target = Player.instance.transform;
    }
    public void AddToList(WayPoint wayPoint)
    {
        WayPoints.Add(wayPoint);
    }
    public void RemoveFromList(WayPoint wayPoint)
    {
        WayPoints.Remove(wayPoint);
    }

    void Update()
    {
        if(Input.GetMouseButton(0) || true)
        {
            CheckDisable();
        }
    }
    void CheckDisable()
    {
        foreach(WayPoint wayPoint in WayPoints)
        {
            Vector3 dist = wayPoint.transform.position - Target.transform.position;
            if(dist.sqrMagnitude < DistanceSquaredToDisable)
                    wayPoint.Show(true);
            else
                    wayPoint.Show(false);
        }
    }
}
