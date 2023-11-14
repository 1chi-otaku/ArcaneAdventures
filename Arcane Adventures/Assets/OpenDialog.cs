using UnityEngine;

public class OpenDialog : MonoBehaviour
{
    public string stringText;
    public Sprite characterSprite; // Спрайт для персонажа
    public DialogueWindow dialogueWindow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueWindow.Show(stringText, characterSprite);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueWindow.Hide();
        }
    }
}
