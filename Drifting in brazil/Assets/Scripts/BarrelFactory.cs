using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelFactory : MonoBehaviour
{
    public GameObject barrel;
    public Transform barrelSpawn;

    private float lastSpawnTime;
    public float spawnRate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time - lastSpawnTime >= 1f / spawnRate)
        {
            Instantiate(barrel, barrelSpawn.position, barrelSpawn.rotation, null);
            lastSpawnTime = Time.time;
        }
    }
}
