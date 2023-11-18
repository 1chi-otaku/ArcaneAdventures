using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public Animator animator;
    public int maxhealth = 100;
    int currenthealth;
    public Slider healthbar;

    private float speed = 0.3f;
    private float attackrange = 0.33f;
    public int positionofPatrol;
    public Transform point;
    bool movingright;
    Transform player;
    public float stopppingDistance;
    bool chill = false;
    bool back = false;
    bool angry = false;
    SpriteRenderer sr;

    private float timeBtwAttack=0;
    public float startTimeBtwAttack;
    private bool isAttacking =false  ;
    private bool isalive = true;
    void Start()
    {
        currenthealth = maxhealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetBool("IsPatrolling", true);
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        healthbar.value = currenthealth;

        if(isAttacking )
        {
            speed = 0;
        }
        if (Vector3.Distance(transform.position, point.position) < positionofPatrol && angry == false)
        {
            chill = true;
        }
        if (Vector3.Distance(transform.position, player.position) < stopppingDistance)
        {
            angry = true;
            chill = false;
            back = false;
        }
        if (Vector3.Distance(transform.position, player.position) > stopppingDistance)
        {
            back = true;
            angry = false;
        }
        //Debug.Log(Vector3.Distance(transform.position, player.position));
        if (chill)
        {
            Chill();
        }
        else if (angry)
        {
            Angry();
        }
        else if (back)
        {
            Back();
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (isalive)
        {
            if (other.CompareTag("Player"))
            {
                if (timeBtwAttack <= 0)
                {
                    animator.SetBool("IsAttacking", true);
                    PlayerControl.Damage(10);
                    timeBtwAttack = startTimeBtwAttack;
                    isAttacking = true;
                    AudioSource audioSource = GetComponent<AudioSource>();
                    audioSource.Play();
                }
                else
                {
                    timeBtwAttack -= Time.deltaTime;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("IsAttacking", false); 
        isAttacking=false;
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    animator.SetBool("IsAttacking", true);
    //    PlayerControl.Damage(10);
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    animator.SetBool("IsAttacking", false);
    //}
    void Chill()
    {
        animator.SetBool("IsChasing", false);
        if (transform.position.x > point.position.x + positionofPatrol)
        {
            movingright = false;
        }
        else if (transform.position.x < point.position.x - positionofPatrol)
        {
            movingright = true;
        }
        if (movingright)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }
    }
    void Angry()
    {
        animator.SetBool("IsChasing", true);

        //animator.transform.LookAt(player);
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 0.7f;
        if (transform.position.x < player.position.x)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }

    }
    void Back()
    {
        animator.SetBool("IsChasing", false);
        speed = 0.3f;
        transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        if (transform.position.x < point.position.x)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }
    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        animator.SetTrigger("Hurt");
        if (currenthealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Vector3 currentpostion = transform.position;
        animator.SetBool("Dead", true);
        healthbar.gameObject.SetActive(false);
        transform.position = new Vector3(currentpostion.x, currentpostion.y - 0.1f, currentpostion.z);
        GetComponent<Collider>().enabled = false;
        this.enabled = false;
        isalive = false;
        NikitaOpenDialog.countkilled++;
    }

}
