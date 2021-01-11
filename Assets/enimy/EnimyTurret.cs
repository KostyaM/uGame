using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyTurret : DamageableComponent
{
    public float range;
    private Transform target;
 
    Vector2 direction;
    public GameObject weapon;
    public GameObject bullet;
    public Transform bulletPoint;
    public float Force;
    public long shootDelayMillis;
    public GameObject shootEffectPrefab;
    public AudioClip fireSound;

    private bool detected = false;


    private bool isWorking = true;
    public override void DestroyElement(float delay)
    {
        isWorking = false;
        Destroy(gameObject, delay);
    }

    private void Start()
    {
        var objects = GameObject.FindGameObjectsWithTag("Player");
        if (objects.Length != 0)
            target = objects[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWorking || target == null)
            return;

        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (!detected)                
                    detected = true;
                
            }
            else
            {
                if (detected)                
                    detected = false;               
            }
        }
        if (detected)
        {
            weapon.transform.right = direction;
            Shoot();
        }
    }

    private long lastFireMillis = 0;
    void Shoot()
    {
        var now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        if (lastFireMillis + shootDelayMillis > now)
            return;
        GameObject BulletIns = Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
        gameObject.GetComponent<AudioSource>().PlayOneShot(fireSound);
        var shootEffect = Instantiate(shootEffectPrefab, bulletPoint.position, bulletPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(direction * Force, ForceMode2D.Impulse);
        lastFireMillis = now;
        Destroy(shootEffect, 0.2f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
