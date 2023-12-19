using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamge : MonoBehaviour
{
    public AudioSource ls;
    private void Start()
    {
        ls.Play();
        StartCoroutine(DestroyAfterSeconds(1f));
    }

    IEnumerator DestroyAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerControl.Damage(33);
        }
    }
    
}
