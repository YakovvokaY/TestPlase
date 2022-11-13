using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] GameObject spawnObj;
    [SerializeField] Transform spawnPoint;
    private float nextSpavnTime = 10;
    void Update()
    {
        if (Time.time > nextSpavnTime && spawnObj != null && spawnPoint != null)
        {
            Instantiate(spawnObj, spawnPoint);
            nextSpavnTime = Time.time + 10;
        }
    }
}