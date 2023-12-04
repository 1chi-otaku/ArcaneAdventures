using Photon.Pun.Demo.SlotRacer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MonoBehaviour
{
    public GameObject menuCanvas; // Ссылка на ваше внутриигровое меню
    public PlayerControl playerControl;
    public float originalVolume;
    private void Start()
    {
        // По умолчанию скрываем меню при старте
        menuCanvas.SetActive(false);
    }

    private void Update()
    {
        // При нажатии на клавишу "Esc"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuCanvas.activeSelf)
            {
                // Если меню уже открыто, закрываем его
                CloseMenu();
            }
            else
            {
                // Если меню закрыто, открываем его
                OpenMenu();
            }
        }
    }

    // Функция открытия меню
    private void OpenMenu()
    {
        originalVolume = playerControl.sprintSound.volume;
        // Показываем меню
        menuCanvas.SetActive(true);

        playerControl.sprintSound.volume = 0f;
        playerControl.footstepsSound.volume = 0f;

        // Замораживаем время
        Time.timeScale = 0f;
    }

    // Функция закрытия меню
    private void CloseMenu()
    {
        playerControl.sprintSound.volume = originalVolume;
        playerControl.footstepsSound.volume = originalVolume;
        // Скрываем меню
        menuCanvas.SetActive(false);

        // Возобновляем время
        Time.timeScale = 1f;
    }
}