using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform weapon;
    public GameObject bulletPrefab;
    public long shootDelayMillis;
    public float weaponAngel = 0f;

    // Update is called once per frame
    void Update()
    {
        HandleAiming();
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }


    private long lastFireMillis = 0;
    private void Shoot() 
    {
        var now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        if (lastFireMillis + shootDelayMillis > now)
            return;
        lastFireMillis = now;
        var bulletPoint = weapon.GetChild(0);
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
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
