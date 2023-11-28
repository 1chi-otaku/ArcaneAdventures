using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class NikitaOpenDialog : MonoBehaviour, IDataPersistence
{
    public string stringText;
    public NIkitaWindow dialogueWindow;
    public Canvas task;
    public static int countkilled=0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (countkilled >= 5)
            {
                dialogueWindow.Show("Проход в пещеру открыт");
                load.col.enabled = true;
            }

            else dialogueWindow.Show(stringText);
            task.enabled = false;

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueWindow.Hide();
         }
    }

    public void LoadData(GameData data)
    {
        countkilled = data.KilledSkeleons;
    }

    public void SaveData(ref GameData data)
    {
        data.KilledSkeleons = countkilled;
    }
}
