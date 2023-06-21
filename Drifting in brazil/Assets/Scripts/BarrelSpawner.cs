using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BarrelSpawner : MonoBehaviour
{
    public UnityEvent Spawn;
    public GameObject barrelCluster;
    public Transform barrelClusterSpawn;


    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(barrelCluster, barrelClusterSpawn.position, barrelClusterSpawn.rotation, null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
