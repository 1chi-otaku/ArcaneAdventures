using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene3 : MonoBehaviour
{
    public GameObject player;
    public string scene;
    public static Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            DataPersisteneManager dataPersistence = FindObjectOfType<DataPersisteneManager>();
            if (dataPersistence != null)
            {
                dataPersistence.enabled = false;
            }

            SceneManager.LoadScene(scene);
        }
    }
}
