using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 20;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    Vector3 pos;
    public AudioSource attackClip;
    public void Attack()
    {
        pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        pos += transform.forward * attackOffset.z;

        Collider[] colInfo = Physics.OverlapSphere(pos, attackRange, attackMask);
        foreach (Collider col in colInfo)
        {
            if(col != null)
            {
                PlayerControl.Damage(attackDamage); 
                attackClip.Play();  
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (pos == null) return;
        Gizmos.DrawWireSphere(pos, attackRange);
    }
    void Start()
    {
        pos= transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        pos += transform.forward * attackOffset.z;
    }

    void Update()
    {
        
    }
}
