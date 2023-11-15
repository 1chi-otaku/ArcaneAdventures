using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        PlayerControl.AddHP();
        gameObject.SetActive(false);
    }
}
