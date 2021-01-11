using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{

    public GameObject[] drops;
    public long dropIntervalMillis;

    private GameObject drop;

    // Update is called once per frame
    private long lastDropMillis = 0;
    void Update()
    {
        if (drop != null)
            return;
        var now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        if (lastDropMillis + dropIntervalMillis >  now)
            return;

        var dropPrefab = drops[UnityEngine.Random.Range(0, drops.Length)];
        var x = UnityEngine.Random.Range(-5, 31);


        transform.position = Vector2.MoveTowards(transform.position, new Vector2(x, 0f), 60);
        Debug.Log("X " + x);

        drop = Instantiate(dropPrefab, transform, false);
        lastDropMillis = now;
    }
}