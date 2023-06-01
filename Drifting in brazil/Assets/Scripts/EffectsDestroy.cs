using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsDestroy : MonoBehaviour
{
    public float lifetime;

    public float lifetimeCounter = 0;


    // Update is called once per frame
    void Update()
    {
        lifetimeCounter += Time.deltaTime;

        //check if lifetiem count is < lifetime
        if (lifetimeCounter >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
