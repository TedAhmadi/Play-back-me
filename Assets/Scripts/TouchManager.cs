using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public List<GameObject> touchObjects;
    public float TimeIntervalBetweenHits = .8f;
    private float lastEntryTime;
    //public static int count = 0;
    public void AddToList(GameObject obj)
    {
        //if (touchObjects.Count == 0 || Time.time - lastEntryTime > TimeIntervalBetweenHits)
        //{
            touchObjects.Add(obj);
            //lastEntryTime = Time.time;
            //count++;
            //print("Object added to list");
        //}
    }
}
