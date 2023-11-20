using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class EnterPlatformer : MonoBehaviour
{
    private bool cutscenePlayed = false;
    public PlayableDirector cutsceneDirector; // ссылка на таймлайн катсцены

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (!cutscenePlayed)
                {
                    cutsceneDirector.stopped += OnCutsceneEnd; // подписываемся на событие окончания воспроизведения
                    cutsceneDirector.Play();

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