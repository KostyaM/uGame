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
    public GameObject weaponBar;

    public long shootDelayMillis;
    public long throwBombDelayMillis;
    public float weaponAngel = 0f;
    public float buletForce = 10;
    public float throwForce;

    public int bulletsCount;
    public int heCount;

    private void Start()
    {
        weaponBar.GetComponent<WeaponPreview>().onBulletChange(bulletsCount);
        weaponBar.GetComponent<WeaponPreview>().onHeChange(heCount);
    }

    public void addBullets(int count)
    {
        bulletsCount += count;
        weaponBar.GetComponent<WeaponPreview>().onBulletChange(bulletsCount);
    }

    public void addHe(int count)
    {
        heCount += count;
        weaponBar.GetComponent<WeaponPreview>().onHeChange(heCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (Menu.isGamePaused)
            return;
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
    private long lastThrowBombMillis = 0;

    private void ThrowBomb()
    {
        if (heCount == 0)
            return;
        Debug.Log("Bomb");
        var now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        if (lastThrowBombMillis + throwBombDelayMillis > now)
            return;
        var bulletPoint = weapon.GetChild(0);
        var bomb = Instantiate(bombPrefab, bulletPoint.position, bulletPoint.rotation);

        var x = throwForce * Mathf.Cos(weaponAngel * Mathf.Deg2Rad);
        var y = throwForce * Mathf.Sin(weaponAngel * Mathf.Deg2Rad);
        bomb.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y), ForceMode2D.Impulse);
        heCount--;
        weaponBar.GetComponent<WeaponPreview>().onHeChange(heCount);
    }
    private void Shoot() 
    {
        if (bulletsCount == 0)
            return;
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
        bulletsCount--;
        weaponBar.GetComponent<WeaponPreview>().onBulletChange(bulletsCount);
    }

    private void HandleAiming() 
    {
        var mousePosition = Utils.GetMouseWorldPosition();
        var aimDirtection = (mousePosition - transform.position).normalized;
        var angel = Mathf.Atan2(aimDirtection.y, aimDirtection.x) * Mathf.Rad2Deg;
        weapon.eulerAngles = new Vector3(0, 0, angel);
        weaponAngel = weapon.GetChild(0).transform.eulerAngles.z;
    }
}
