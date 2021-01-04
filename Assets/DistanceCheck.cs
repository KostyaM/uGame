using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheck : MonoBehaviour
{
    public GameObject listener;
    public GameObject surface;
    public float minAltitude;
    public float maxAltitude;
    public float insaneDistance;


    // Update is called once per frame
    void Update()
    {
        var distance = Physics2D.Distance(surface.transform.GetComponent<Collider2D>(), transform.GetComponent<Collider2D>()).distance;
        if (distance < minAltitude)
        {
            listener.GetComponent<DistanceCheckListener>().onMinDistance();
        } else if(distance > maxAltitude){
            listener.GetComponent<DistanceCheckListener>().onMaxDistance();
        }

        if(distance > insaneDistance)
            listener.GetComponent<DistanceCheckListener>().onInsaneDistance();
    }
}
