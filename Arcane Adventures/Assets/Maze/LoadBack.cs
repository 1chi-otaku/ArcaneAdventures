using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBack : MonoBehaviour
{
    public GameObject player;
    public string scene;
    public Transform spawnPoint; 


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            SceneManager.LoadScene(scene);
            player.transform.position = spawnPoint.position;
        }
    }
}
