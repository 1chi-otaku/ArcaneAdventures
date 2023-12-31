using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    private AudioSource finishSound;
    private Animator animator;

    private bool levelCompleted = false;

    void Start()
    {
        finishSound= GetComponent<AudioSource>();
        animator= GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            PlayerPrefs.SetInt("PlatformerCompleted", PlayerPrefs.GetInt("PlatformerCompleted") + 1);
            PlayerPrefs.Save();
            levelCompleted = true;
            finishSound.Play();
            Invoke("Finish", 3f);
            animator.SetTrigger("complete");
            Debug.Log(PlayerPrefs.GetInt("PlatformerCompleted"));

        }
    }

    private void Finish()
    {
        SceneManager.LoadScene("GameScene2");
    }


}
