using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBehaviour : MonoBehaviour
{

    public float impulse;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            collision.gameObject.transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, impulse), ForceMode2D.Impulse);
        }
        catch (Exception e) { 

        }

            
     }
}
