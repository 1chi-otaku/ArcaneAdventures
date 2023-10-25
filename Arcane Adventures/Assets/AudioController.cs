using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    private float interval = 10.0f;

    private void Start()
    {
        audioSource = GetComponent < AudioSource>();
        StartCoroutine(PlayAudioWithInterval());
    }

    private IEnumerator PlayAudioWithInterval()
    {
        while (true)
        {
            audioSource.PlayOneShot(audioClip);
            yield return new WaitForSeconds(interval);
        }
    }
}
