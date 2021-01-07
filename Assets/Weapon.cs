using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject shootEffectPrefab;
    public Transform weapon;
    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    public AudioClip fireSound;

    public long shootDelayMillis;
    public float weaponAngel = 0f;
    public float buletForce = 10;
    public float throwForce;

    // Update is called once per frame
    void Update()
    {
        HandleAiming();
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            ThrowBomb();
        }
    }


    private long lastFireMillis = 0;

    private void ThrowBomb()
    {
        var bulletPoint = weapon.GetChild(0);
        var bomb = Instantiate(bombPrefab, bulletPoint.position, bulletPoint.rotation);

        var x = throwForce * Mathf.Cos(weaponAngel * Mathf.Deg2Rad);
        var y = throwForce * Mathf.Sin(weaponAngel * Mathf.Deg2Rad);
        bomb.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }
    private void Shoot() 
    {
        var now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        if (lastFireMillis + shootDelayMillis > now)
            return;
        gameObject.GetComponent<AudioSource>().PlayOneShot(fireSound);
        var bulletPoint = weapon.GetChild(0);
        var bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        var weaponAngel = bullet.transform.eulerAngles.z;

        var x = buletForce * Mathf.Cos(weaponAngel * Mathf.Deg2Rad);
        var y = buletForce * Mathf.Sin(weaponAngel * Mathf.Deg2Rad);
        var shootEffect = Instantiate(shootEffectPrefab, bulletPoint.position, bulletPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y), ForceMode2D.Impulse);
        lastFireMillis = now;
        Destroy(shootEffect, 0.2f);
    }

    private void HandleAiming() 
    {
        var mousePosition = MouseUtils.GetMouseWorldPosition();
        var aimDirtection = (mousePosition - transform.position).normalized;
        var angel = Mathf.Atan2(aimDirtection.y, aimDirtection.x) * Mathf.Rad2Deg;
        weapon.eulerAngles = new Vector3(0, 0, angel);
        weaponAngel = weapon.GetChild(0).transform.eulerAngles.z;
    }
}
