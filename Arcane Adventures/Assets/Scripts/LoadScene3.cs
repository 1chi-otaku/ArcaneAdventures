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
            KeyManager keyManager = FindObjectOfType<KeyManager>();
            if (keyManager != null)
            {
                // Получение количества ключей
                int keyCount = keyManager.KeysCount;

                // Ваш код, использующий keyCount
                Debug.Log("Key Count: " + keyCount);
               

                // Загрузка сцены
                if(keyCount == 3)
                {
                    DataPersisteneManager dataPersistence = FindObjectOfType<DataPersisteneManager>();
                    if (dataPersistence != null)
                    {
                        dataPersistence.enabled = false;
                    }
                    SceneManager.LoadScene(scene);
                }
                
            }
            else
            {
                Debug.LogError("KeyManager not found in the scene!");
            }

        }
    }
}
