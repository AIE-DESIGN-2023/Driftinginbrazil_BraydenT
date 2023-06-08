using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToEachFrame : MonoBehaviour
{
    public GameObject ObjectToTeleportTo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (ObjectToTeleportTo.transform.position);
    }
}
