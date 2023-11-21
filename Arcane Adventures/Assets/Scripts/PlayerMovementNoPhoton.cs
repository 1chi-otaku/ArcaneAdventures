//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerControlNoPhoton : MonoBehaviour
{
    public float speed;
    public float slowSpeed;
    public float groundDist;
    public bool isMovementAllowed = true;

    public AudioSource footstepsSound, sprintSound;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;
    public Animator animator;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (isMovementAllowed)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
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


            animator.SetFloat("Speed", Mathf.Abs(x));
            animator.SetFloat("VerticalSpeed", Mathf.Abs(y));
            Vector3 moveDir = new Vector3(x, 0, (float)(y * (speed / 1.2)));


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
}

