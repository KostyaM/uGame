using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyCabineElementHit : EnimyComponent, CollisionListener
{
    public override void DestroyElement()
    {
        transform.parent.GetComponent<EnimyComponentCabine>().DestroyElement();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 700;
    }


    public void onCollide()
    {

        transform.parent.GetComponent<EnimyComponentCabine>().DestroyElement();
    }


    public void onExitCollide()
    {

        transform.parent.GetComponent<EnimyComponentCabine>().DestroyElement();

    }
}
