using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isFlipped=false;
    private int health = 300;
    public Slider slider;
    public AudioSource audioSource;
    public Canvas bosscanvas;
    public bool secondpart = false;

    public bool isInvulnerable =false;

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
        if(isInvulnerable) { return; }
        if(health > 0)
        {
            if (secondpart)
            {
                health -= dmg - 10;

            }
            else
            {
                health -= dmg;
            }
        }
        else if(health <= 0 && secondpart ==true)
        {
            audioSource.Play();
            gameObject.GetComponent<Animator>().SetTrigger("isDead");
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Collider>().enabled = false;
            Vector3 currentPosition = transform.position;
            currentPosition.y = -0.93f;
            transform.position = currentPosition;
            bosscanvas.enabled = false;
        }
        else if(health <= 0) 
        {
            audioSource.Play();
            gameObject.GetComponent<Animator>().SetTrigger("Armour");
            secondpart = true;
        }
    }
    public void SecondPart()
    {
        health = 600;
        slider.maxValue = 600;
        slider.value = health;
    }
    void Update()
    {
        slider.value = health;   
    }
}
