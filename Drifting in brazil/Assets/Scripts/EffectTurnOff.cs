using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTurnOff : MonoBehaviour
{
    public float lifetime;

    public float lifetimeCounter = 0;

    void Update()
    {
        lifetimeCounter += Time.deltaTime;

        //check if lifetiem count is < lifetime
        if (lifetimeCounter >= lifetime)
        {
            gameObject.SetActive(false);
        }
    }
}
