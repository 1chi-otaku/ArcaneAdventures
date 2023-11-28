using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour
{
    private AudioSource bulk;
    private void Start()
    {
        bulk = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerControl.AddHP();
        bulk.Play();
        gameObject.SetActive(false);
    }
}
