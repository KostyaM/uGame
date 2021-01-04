using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public float buletForce = 3;
    public Rigidbody2D bullet;
    // Start is called before the first frame update
    void Start()
    {
        var weaponAngel = bullet.transform.eulerAngles.z;

        var x = buletForce * Mathf.Cos(weaponAngel * Mathf.Deg2Rad);
        var y = buletForce * Mathf.Sin(weaponAngel * Mathf.Deg2Rad);
        bullet.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit " + collision.name);
         var enimyComponent =  collision.GetComponent<EnimyComponent>();
        if (enimyComponent != null)
            enimyComponent.Damage(300);

       Destroy(gameObject);
    }

}
