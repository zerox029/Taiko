using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chart : MonoBehaviour {

    public List<GameObject> hitObjects;
    public List<float> timings;

    public float hitTimingWindow;

    public void RemoveFirstHitcirle()
    {
        Destroy(hitObjects[0]);
        hitObjects.RemoveAt(0);
        timings.RemoveAt(0);
    } 
}
