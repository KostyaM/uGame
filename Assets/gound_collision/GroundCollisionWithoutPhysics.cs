using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionWithoutPhysics : GroundCollision
{

    public GameObject collidableObject;
    void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        Physics.IgnoreCollision(transform.GetComponent<Collider>(), collision.transform.parent.GetComponent<Collider>(), true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        base.OnCollisionExit2D(collision);
       
    }
}
