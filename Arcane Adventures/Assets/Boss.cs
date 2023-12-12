using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isFlipped=false;
    private int health = 400;
    public Slider slider;
    public AudioSource audioSource;
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if(transform.position.x > player.position.x && isFlipped)
        {   
            transform.localScale=flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f,180f,0f);
            isFlipped = true;
        }
    }
    public void Damage(int dmg)
    {
        if(health > 0)
        {
            health -= dmg;
        }
        else
        {
            audioSource.Play();
            gameObject.GetComponent<Animator>().SetTrigger("isDead");
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Collider>().enabled = false;
            Vector3 currentPosition = transform.position;
            currentPosition.y = -0.93f; 
            transform.position = currentPosition;
            slider.enabled = false;
        }
    }
    void Update()
    {
        slider.value = health;   
    }
}
