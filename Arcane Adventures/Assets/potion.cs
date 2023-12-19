using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour
{
    public AudioSource bulk;
    private void OnTriggerEnter(Collider other)
    {
        PlayerControl.AddHP();
        bulk.Play();
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(DestroyAfterDelay(1f));
    }
    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
