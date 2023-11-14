using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlatformer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверьте, что в триггер входит объект с тегом "Player" (ваш персонаж)
        {
            // Измените сцену на целевую
            SceneManager.LoadScene("Platformer-1");
            Debug.Log("GGG");
        }
    }
}
