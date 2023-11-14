using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fox") && !hasTriggered)
        {
            dialogueBox.SetActive(true);
            hasTriggered = true;
        }
    }
}
