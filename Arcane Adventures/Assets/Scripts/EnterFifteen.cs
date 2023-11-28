using Photon.Pun.Demo.SlotRacer;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EnterFifteen : MonoBehaviour
{
    public DataPersisteneManager manager;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                DataPersisteneManager.instance.SaveGame();
                SceneManager.LoadScene("15");
            }
        }
    }

}
