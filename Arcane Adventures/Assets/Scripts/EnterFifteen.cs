using Photon.Pun.Demo.SlotRacer;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EnterFifteen : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene("15");
            }
        }
    }

}
