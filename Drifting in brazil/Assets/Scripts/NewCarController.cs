using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCarController : MonoBehaviour
{
    public float MovementSpeed = 15f;
    public float MaxSpeed = 10f;
    public float Drag = 0.98f;
    public float SteerAngle = 20;
    public float Traction = 0.5f;

    //variables for char controller
    private CharacterController characterController;
    private Vector3 Movement;
    private float verticalVelocity;



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //moving
        float verticalMovement = Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;
        Movement = transform.forward * verticalMovement;
        Debug.Log("moving forward");

        //steering
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * Movement.magnitude * SteerAngle * Time.deltaTime);
        Debug.Log("moving sideways");

        //drag and max speed limit
        Movement *= Drag;
        Movement = Vector3.ClampMagnitude(Movement, MaxSpeed);

        //traction & debug
        Debug.DrawRay(transform.position, Movement.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        Movement = Vector3.Lerp(Movement.normalized, transform.forward, Traction * Time.deltaTime) * Movement.magnitude;
    }
}
