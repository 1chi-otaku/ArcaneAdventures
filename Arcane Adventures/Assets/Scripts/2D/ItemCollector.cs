using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private Text scoreText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BlueOrb"))
        {

            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            score += 10;
            scoreText.text = "SCORE: " + score;
        }
        else if (collision.gameObject.CompareTag("YellowOrb"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            score += 30;
            scoreText.text = "SCORE: " + score;
        }

    }
}
