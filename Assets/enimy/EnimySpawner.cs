using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimySpawner : MonoBehaviour
{
    public GameObject enimyPrefub;
    public long respawnIntervalMillis;
    private GameObject enimy;
    public GameObject stat;

    // Start is called before the first frame update
    void Start()
    {
        respawn();
    }

    // Update is called once per frame
    private long deathInMillis = 0;
    private bool needRespawn = true;
    void Update()
    {
        var now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        if (needRespawn && deathInMillis + respawnIntervalMillis <= now)
            respawn();
        if (enimy == null)
        {
            if (!needRespawn)
            {
                deathInMillis = now;
                stat.GetComponent<EnimyKillListener>().OnKill();
            }
            needRespawn = true;
        }
    }

    private void respawn()
    {
        if (!needRespawn)
            return;
        enimy = Instantiate(enimyPrefub, transform.position, transform.rotation);
        needRespawn = false;
    }
}
