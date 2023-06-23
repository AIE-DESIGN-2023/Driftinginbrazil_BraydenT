using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject GameObjectToSpawn;
    public Transform spawnpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(GameObjectToSpawn, spawnpoint.position, spawnpoint.rotation, null);
        }
    }
}
