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
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            levelCompleted = true;
            finishSound.Play();
            Invoke("Finish", 3f);
            animator.SetTrigger("complete");

        }
    }

    private void Finish()
    {
        SceneManager.LoadScene("GameScene2");
    }


}
