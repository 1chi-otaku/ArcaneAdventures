using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Speedfly : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    public AudioSource audioSource;
    Transform player;
    Collider that;
    SpriteRenderer that1;
    void Start()
    {
        //rb.velocity = -transform.right * speed;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        that1 = gameObject.GetComponent<SpriteRenderer>();
        that = gameObject.GetComponent<Collider>();
        Vector3 direction = (player.position - transform.position).normalized;
        if (transform.rotation.y == 0)
            direction.x += 0.1f;
        else direction.x -= 0.1f;
        rb.velocity = direction * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //другой вариант
            //PlayerControl player = other.GetComponent<PlayerControl>();
            //if(player != null) 
            //{
            //    //функия дамага player.Damage(20);
            //}
            audioSource.Play();
            PlayerControl.Damage(20);
            that1.enabled = false;
            that.enabled = false;
            WaitAndDoSomething();

        }
        else if(other.tag != "Golem")
        {
            //that.enabled = false;
            that1.enabled = false;
            WaitAndDoSomething();
        }
    }
    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
