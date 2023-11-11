using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float slowSpeed;
    public float groundDist;

    public Transform attackPoint;
    public float range = 0.5f;
    public LayerMask enemyLayer;
    public float attackTime = 1f;
    float nextTimeAttack = 0f;


    private PhotonView photonView;

    
    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;
    public Animator animator;

    private static int HP = 100;
    public Slider health;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        photonView = gameObject.GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            health.value = HP;
            RaycastHit hit;
            Vector3 castpos = transform.position;
            castpos.y += 1;

            if (Physics.Raycast(castpos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
            {

                if (hit.collider != null)
                {
                    Vector3 movepos = transform.position;
                    movepos.y = hit.point.y + groundDist;
                    transform.position = movepos;
                }

            }

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            if(Time.time >= nextTimeAttack)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetTrigger("Attack");
                    Collider[] hitenemies = Physics.OverlapSphere(attackPoint.position, range, enemyLayer);
                    foreach (Collider enemy in hitenemies)
                    {
                        enemy.GetComponent<EnemyDamage>().TakeDamage(20);
                    }
                    nextTimeAttack = Time.time + 1f / attackTime;
                }
            }

            animator.SetFloat("Speed", Mathf.Abs(x));
            animator.SetFloat("VerticalSpeed", Mathf.Abs(y));
            Vector3 moveDir = new Vector3(x, 0, (float)(y * (speed / 1.6)));


            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                rb.velocity = moveDir * slowSpeed;
            }
            else
            {
                rb.velocity = moveDir * speed;
            }

            if (x != 0 && x < 0)
            {
                sr.flipX = true;
            }
            else if (x != 0 && x > 0)
            {
                sr.flipX = false;
            }
        }
    }
    public static void Damage(int dmg)
    {
        HP -= dmg;
        if(HP <= 0)
        {
            SceneManager.LoadScene("GameScene2");
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, range);
    }
}