using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarController : MonoBehaviour
{

    // Settings
    public float Speed = 50;
    public float ActiveSpeed;
    public float MaxSpeed = 15;
    public float MoveSpeed;
    public float NitroSpeed;
    public float Drag = 0.98f;
    public float ActiveDrag;
    public float SteerAngle = 20;
    public float Traction = 1;

    public int damageStrength;

    public Image nitroBar;
    public float minNitro = 0;
    public float maxNitro = 10;
    public float currentNitro;
    public bool nitroOn = false;
    private bool refillNitro = false;
    public GameObject nitroFX;

    public GameObject bonkFX;
    public GameObject bonkText;
    public Transform bonkFXspawn;
    public Transform bonkTextSpawn;

    public GameObject ScrapeFX;
    public Transform ScrapeFXSpawn;

    private Vector3 MoveForce;

    Rigidbody rb;
    [SerializeField] TextMeshProUGUI hud;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentNitro = minNitro;
        nitroFX.gameObject.SetActive(false);
        nitroOn = false;

        ActiveSpeed = Speed;
        ActiveDrag = Drag;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveSpeed = ActiveSpeed + NitroSpeed;

        // Moving
        MoveForce += transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        rb.position += MoveForce * Time.deltaTime;

        // Steering
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        // Drag and max speed limit
        MoveForce *= Drag;
        Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        // Traction
        Debug.DrawRay(transform.position, MoveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        //MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (nitroOn == false)
            {
                if (currentNitro >= maxNitro)
                {
                    currentNitro = maxNitro - 0.01f;
                    nitroOn = true;
                }
            }
        }

        if (nitroOn == true)
        {
            NitroActive();
            refillNitro = false;
            nitroFX.gameObject.SetActive(true);
        }
        
        if (nitroOn == false)
        {
            NitroUnactive();
        }

        if (currentNitro < minNitro)
        {
            nitroOn = false;
            Debug.Log("nitro set to false");
            nitroFX.gameObject.SetActive(false);
            refillNitro = true;
            Debug.Log("Adding nitro");
        }

        if (currentNitro > maxNitro)
        {
            currentNitro = maxNitro;
            nitroOn = false;
        }

        if (refillNitro == true)
        {
            currentNitro += Time.deltaTime;
        }
        else
        {
            currentNitro -= Time.deltaTime;
        }

        nitroBar.fillAmount = currentNitro / maxNitro;

    }



    void NitroActive()
    {
        Debug.Log("NitroActive is active");
        NitroSpeed = 5;
        SteerAngle = 25;
    }
    void NitroUnactive()
    {
        NitroSpeed = 0;
        SteerAngle = 35;
    }

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name == "YourWallName")  // or if(gameObject.CompareTag("YourWallTag"))
        rb.velocity = Vector3.zero;

        //ActiveSpeed = 1;
        ActiveDrag = 0;

        Instantiate(ScrapeFX, ScrapeFXSpawn.position, ScrapeFXSpawn.rotation, null);
    }

    private void OnCollisionExit(Collision collision)
    {
        ActiveSpeed = Speed;
        ActiveDrag = Drag;

        Destroy(ScrapeFX);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Damageable")
        {
            Damageable damageable = collision.gameObject.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.Damage(damageStrength);
                Instantiate(bonkFX, bonkFXspawn.position, bonkFXspawn.rotation, null);
                Instantiate(bonkText, bonkTextSpawn.position, bonkTextSpawn.rotation, null);
            }
        }

        {
            //check if the object we hit is tagged enemy
            if (collision.gameObject.tag == "Enemy")
            {
                //check if collision object has enemy health script
                EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damageStrength);
                    Instantiate(bonkFX, bonkFXspawn.position, bonkFXspawn.rotation, null);
                    Instantiate(bonkText, bonkTextSpawn.position, bonkTextSpawn.rotation, null);
                }
            }
        }
    }


}