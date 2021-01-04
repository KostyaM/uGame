using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyComponentCabine : MonoBehaviour, DistanceCheckListener
{
    private bool isWorking = true;
    private bool isCollided = false;
    private bool isMinDistanceReached = false;


    public void DestroyElement()
    {
        isWorking = false;
        Destroy(gameObject);
    }

    public void onMinDistance()
    {
        if(isWorking)
            isMinDistanceReached = true;
    }

    public void onMaxDistance()
    {
        if (isWorking)
            isMinDistanceReached = false;
    }

    public void onInsaneDistance()
    {
        Destroy(gameObject);
        isWorking = false;
    }



    // Update is called once per frame
    private float previousYVelocity = 0f;
  
    void Update()
    {
        if (isMinDistanceReached)
        {
            var velocity = GetComponent<Rigidbody2D>().velocity.y;
            float impulse = 0f;
           
            if (velocity < 0)
            {

                impulse = Mathf.Abs((previousYVelocity - velocity < 0 ? velocity : 0) / 1.5f);
                previousYVelocity = velocity;

            }
            else 
            {
                impulse = Mathf.Abs(((velocity - previousYVelocity < 0 ? velocity : 0) / 1.5f));
                previousYVelocity = velocity;
            }
           
            impulse += 0.1f;

            var engine1 = transform.GetChild(0).GetComponent<EnimyComponentEngine>();
            var engine2 = transform.GetChild(1).GetComponent<EnimyComponentEngine>();
            if (engine1 != null)
                engine1.MakeImpulse(impulse);
            if (engine2 != null)
                engine2.MakeImpulse(impulse);
        }
           
               
            
            
    }

}
