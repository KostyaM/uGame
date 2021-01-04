using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyComponentEngine : EnimyComponent
{


    private bool isWorking = true;
   
    public override void DestroyElement()
    {
        isWorking = false;
        Destroy(gameObject);    
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 300;
    }

    public void MakeImpulse(float power) {
        if (!isWorking)
            return;
        var spaceShip = transform.parent.GetComponent<Rigidbody2D>();
        var angel = (90 + transform.eulerAngles.z) * Mathf.Deg2Rad;
        var x = power * Mathf.Cos(angel);
        var y = power * Mathf.Sin(angel);
        spaceShip.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }

}
