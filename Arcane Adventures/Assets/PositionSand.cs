using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionSand : MonoBehaviour
{
    private Vector3 initialPlayerPosition; // начальное местоположение игрока

    private void Start()
    {
        // Сохраняем начальное местоположение игрока при старте сцены
        initialPlayerPosition = new Vector3(4.81f, 0.24f, 19.31f);
        Debug.Log("FGGGG");
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        // Устанавливаем местоположение игрока при загрузке сцены
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = initialPlayerPosition;
        }
    }
}
