using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public Animator animator;
    public int maxhealth = 100;
    int currenthealth;
    public Slider healthbar;
    void Start()
    {
        currenthealth = maxhealth;
    }
    private void Update()
    {
        healthbar.value = currenthealth;

    }
    public void TakeDamage(int damage)
    {
        currenthealth -=damage;
        animator.SetTrigger("Hurt");
        if(currenthealth <= 0) 
        {
            Die();
        }
    }
    void Die()
    {
        Vector3 currentpostion = transform.position;
        animator.SetBool("Dead", true);
        healthbar.gameObject.SetActive(false);
        transform.position = new Vector3(currentpostion.x, currentpostion.y-0.1f, currentpostion.z);
        GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }

}
