using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{

    public GameObject collidableObject;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            collidableObject.GetComponent<CollisionListener>().onCollide();
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            collidableObject.GetComponent<CollisionListener>().onExitCollide();
        }
    }
}
