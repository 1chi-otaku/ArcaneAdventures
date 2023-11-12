using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDialog : MonoBehaviour
{
    public string stringtext;
    public DialogueWindow dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            dialogue.Show(stringtext);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue.Hide();
        }
    }
}
