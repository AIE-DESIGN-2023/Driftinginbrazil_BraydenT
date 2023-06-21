using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public GameObject ObjectToOff;
    public GameObject ObjectToOn;
    public GameObject ObjectToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("entered triggerbox");
            ActivateObject();
            DeactivateObject(); 
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        Destroy(ObjectToDestroy.gameObject);
    }

    void DeactivateObject()
    {
        ObjectToOff.gameObject.SetActive(false);
    }

    void ActivateObject()
    {
        ObjectToOn.gameObject.SetActive(true);
    }
}
