using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class endtimeline : MonoBehaviour
{
    private PlayableDirector playableDirector;

    private void Start()
    {
        // Получаем компонент PlayableDirector на этом объекте
        playableDirector = GetComponent<PlayableDirector>();

        // Подписываемся на событие завершения таймлайна
        if (playableDirector != null)
        {
            playableDirector.stopped += OnTimelineStopped;
        }
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        // Перезагружаем сцену
        SceneManager.LoadScene("GameScene2");

    }
}
