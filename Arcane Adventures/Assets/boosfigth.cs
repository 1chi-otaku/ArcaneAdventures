using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class boosfigth : MonoBehaviour
{
    public GameObject border1;
    public GameObject border2;
    public GameObject boss;
    public AudioSource audio;
    public AudioSource bossaudio;
    public PlayableDirector cutsceneboss;
    private void OnTriggerEnter(Collider other)
    {
        border1.GetComponent<Collider>().enabled = true;
        border2.GetComponent<Collider>().enabled = true;
        boss.SetActive(true);
        Destroy(audio);
        bossaudio.Play();
        cutsceneboss.Play();
        gameObject.SetActive(false);
    }

    
}
