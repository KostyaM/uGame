using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimySpawner : MonoBehaviour
{
    public GameObject enimyPrefub;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enimyPrefub, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
