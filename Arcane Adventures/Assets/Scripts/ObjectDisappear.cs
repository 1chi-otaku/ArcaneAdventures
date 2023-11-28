using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDisappear : MonoBehaviour
{
    public GameObject targetObject;
    public Canvas EpromptCanvas;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                targetObject.SetActive(false);
                EpromptCanvas.enabled = false;
            }
        }
    }
}
