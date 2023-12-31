using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour, IDataPersistence
{
    public float speed;
    public float slowSpeed;
    public float groundDist;

    public Transform attackPointright;
    public Transform attackPointleft;
    public float range = 0.5f;
    public LayerMask enemyLayer;
    public float attackTime = 2f;
    float nextTimeAttack = 0f;


    private NPCController npc;

    public Canvas EpromptCanvas;



    private PhotonView photonView;
    public AudioSource footstepsSound, sprintSound;


    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;
    public Animator animator;

    public float timeBtwAttack=0;
    public float timeBtwDefanse=0;
    float starttimeBtwAttack=0.25f;
    float starttimeBtwDefense = 2f;
    private static int HP;
    public Slider health;
    public PlayableDirector endcutscene;


    public bool isMovementAllowed = true;
    private static bool isDefense = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        photonView = gameObject.GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        }
        HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine && isMovementAllowed && !InDialogue())
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
     Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (!sprintSound.isPlaying)
                    {
                        sprintSound.Play();
                    }
                    if (footstepsSound.isPlaying)
                    {
                        footstepsSound.Stop();
                    }
                }
                else
                {
                    if (!footstepsSound.isPlaying)
                    {
                        footstepsSound.Play();
                    }
                    if (sprintSound.isPlaying)
                    {
                        sprintSound.Stop();
                    }
                }
            }
            else
            {
                if (footstepsSound.isPlaying)
                {
                    footstepsSound.Stop();
                }
                if (sprintSound.isPlaying)
                {
                    sprintSound.Stop();
                }
            }
        

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

            if(timeBtwAttack <=0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (sr.flipX == false)
                    {
                        Atta�k(attackPointright.position);
                    }
                    else
                    {
                        Atta�k(attackPointleft.position);
                    }
                    AudioSource audioSource = GetComponent<AudioSource>();
                    audioSource.Play();
                    timeBtwAttack = starttimeBtwAttack;

                }
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
            if (timeBtwDefanse <= 0)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartDefense();
                    timeBtwDefanse = starttimeBtwDefense;
                }
            }
            else
            {
                timeBtwDefanse -= Time.deltaTime;
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
        if(HP<=0)
        {
            endcutscene.Play();
            isMovementAllowed = false;
        }
    }
    public static void AddHP()
    {
        if(HP +50 >100)
        HP = 100;
        else {  HP += 50; }
       
    }
    private void Atta�k(Vector3 attackpoint_position)
    {
        animator.SetTrigger("Attack");
        Collider[] hitenemies = Physics.OverlapSphere(attackpoint_position, range, enemyLayer);
        foreach (Collider enemy in hitenemies)
        {
            enemy.GetComponent<EnemyDamage>()?.TakeDamage(10);
        }
        foreach (Collider enemy in hitenemies)
        {
            enemy.GetComponent<Boss>()?.Damage(20);
        }
    }
    public static void Damage(int dmg)
    {
        if(!isDefense)
            HP -= dmg;
        if(HP <= 0)
        {
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPointright == null) return;
        Gizmos.DrawWireSphere(attackPointright.position, range);
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
        HP = data.PlayerHp;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
        data.PlayerHp = HP;
    }
    public void StartDefense()
    {
        animator.SetTrigger("Def");
        isDefense = true;
        Invoke("ResetAnimationFlag", 0.8f); 
    }
    private void ResetAnimationFlag()
    {
        isDefense = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            EpromptCanvas.gameObject.SetActive(true);
            npc = other.gameObject.GetComponent<NPCController>();
            if (Input.GetKey(KeyCode.E))
            {
                other.gameObject.GetComponent<NPCController>().ActivateDialogue();
                EpromptCanvas.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        npc = null;
       //EpromptCanvas.gameObject.SetActive(false);
    }

    private bool InDialogue()
    {
        if (npc != null) return npc.DialogueActive();
        else return false;
    }
}