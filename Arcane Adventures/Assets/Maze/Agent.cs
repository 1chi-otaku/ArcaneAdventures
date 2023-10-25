using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    public Animator an;
    public string scene;
    public AudioClip auc;
    public AudioSource audioSource;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            an.SetTrigger("Scrim");
            audioSource.PlayOneShot(auc);
            StartCoroutine(LoadSceneAfterDelay(1));
        }
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }

}
