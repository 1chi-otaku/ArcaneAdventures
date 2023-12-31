using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    public GameObject player;
    public string scene;
    public static Collider col;
    public DataPersisteneManager manager;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            manager.SaveGame();
            SceneManager.LoadScene(scene);
        }
    }

   
}
