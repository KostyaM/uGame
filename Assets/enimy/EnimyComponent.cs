using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnimyComponent : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;

    public void Damage(int damage)
    {
        health-=damage;
        Debug.Log("Damage " + damage + " health " + health + " Damaged element " + GetType());
        if (health <= 0)
        {
            DestroyElement();
        }
    }

    public abstract void DestroyElement();

   
}
