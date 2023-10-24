using System.Collections;
using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    public float moveSpeed = 0.3f;
    public float maxSpeed = 0.3f;
    public float minSpeed = 0f;
    public float speedChangeInterval = 3.0f; // ”величил интервал, чтобы скорость мен€лась реже
    public Animator animator;
    public SpriteRenderer sr;

    private Vector3 moveDirection;
    private float timer;
    private bool isChangingSpeed;

    void Start()
    {
        SetRandomDirection();
        StartCoroutine(ChangeSpeedPeriodically());
        timer = Random.Range(2, 8); // ”величил интервал случайных смен направлени€
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveSpeed));
        if (!isChangingSpeed && moveSpeed > 0.1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SetRandomDirection();
                timer = Random.Range(2, 8); // ”величил интервал случайных смен направлени€
            }

            if (moveDirection.x < 0)
            {
                sr.flipX = true;
            }
            else if (moveDirection.x > 0)
            {
                sr.flipX = false;
            }

            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    void SetRandomDirection()
    {
        // ћен€ем углы дл€ более частого движени€ по X и Z
        float[] possibleAngles = { 0, 45, 90, 135, 180, 225, 270, 315 };
        float randomAngle = possibleAngles[Random.Range(0, possibleAngles.Length)];
        moveDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;
    }

    IEnumerator ChangeSpeedPeriodically()
    {
        while (true)
        {
            isChangingSpeed = true;
            moveSpeed = 0;
            yield return new WaitForSeconds(Random.Range(minSpeed, maxSpeed));
            moveSpeed = Random.Range(minSpeed, maxSpeed);
            isChangingSpeed = false;
            yield return new WaitForSeconds(speedChangeInterval);
        }
    }

}
