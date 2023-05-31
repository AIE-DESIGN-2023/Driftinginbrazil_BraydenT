using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour

{
    [Tooltip("An array of transforms representing camera positions")]
    [SerializeField] Transform[] povs;
    [Tooltip("The speed at which the camera follows the plane")]
    [SerializeField] float speed;

    private int index = 1;
    private Vector3 target;

    private void Update()
    {
        //numbers represent different povs (can add more)
        if (Input.GetKeyDown(KeyCode.Alpha1)) index = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha1)) index = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha1)) index = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha1)) index = 3;

        //sets our target to the relevant pov
        target = povs[index].position;
    }

    private void FixedUpdate()
    {
        //move camera to desired position
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        transform.forward = povs[index].forward;
    }
}

