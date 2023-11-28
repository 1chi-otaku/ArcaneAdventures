using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class EnterPlatformer : MonoBehaviour
{
    private bool cutscenePlayed = false;
    public PlayableDirector cutsceneDirector; // ссылка на таймлайн катсцены
    public Canvas EPromptCanvas;
    public Canvas HPCanvas;
    public Canvas BlackBars;
    public PlayerControl playerControl;


    private void Update()
    {
        if (cutscenePlayed && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Platformer-1");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (!cutscenePlayed)
                {
                    BlackBars.gameObject.SetActive(true);
                    EPromptCanvas.gameObject.SetActive(false);
                    HPCanvas.gameObject.SetActive(false);
                    cutsceneDirector.stopped += OnCutsceneEnd; // подписываемся на событие окончания воспроизведения
                    cutsceneDirector.Play();
                    playerControl.isMovementAllowed = false;
                    cutscenePlayed = true;
                }
            }
        }
    }

    // Вызывается по окончании воспроизведения катсцены
    private void OnCutsceneEnd(PlayableDirector director)
    {
        // Отписываемся от события, чтобы избежать многократного вызова
        cutsceneDirector.stopped -= OnCutsceneEnd;

        // Загружаем следующую сцену
        SceneManager.LoadScene("Platformer-1");
    }
}