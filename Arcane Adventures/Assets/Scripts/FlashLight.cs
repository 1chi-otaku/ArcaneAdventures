using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Light flashingLight; // Drag your Light object here in the Inspector

    void FixedUpdate()
    {
        float randomNumber = Random.value;

        if (randomNumber <= 0.01f)
        {
            flashingLight.enabled = true;
        }
        else
        {
            flashingLight.enabled = false;
        }
    }

}
