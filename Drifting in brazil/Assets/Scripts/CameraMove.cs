using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject teleportPoint;
    public GameObject cameraToMove;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("moving camera");
            cameraToMove.transform.rotation = teleportPoint.transform.rotation;
            cameraToMove.transform.position = teleportPoint.transform.position;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, teleportPoint.transform.position);
    }
}
