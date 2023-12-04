using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class endtimeline : MonoBehaviour
{
    private PlayableDirector playableDirector;
    public PlayerControl movement;
    public string LoadScene;

    private void Start()
    {
        // Получаем компонент PlayableDirector на этом объекте
        playableDirector = GetComponent<PlayableDirector>();

        // Подписываемся на событие завершения таймлайна
        if (playableDirector != null)
        {
            
            playableDirector.stopped += OnTimelineStopped;
            playableDirector.played += OnTimelineStarted;

        }
    }

    private void OnTimelineStarted(PlayableDirector director)
    {
        movement.isMovementAllowed = false;
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        // Перезагружаем сцену
        movement.isMovementAllowed = true;
        SceneManager.LoadScene(LoadScene);
        

    }
}
