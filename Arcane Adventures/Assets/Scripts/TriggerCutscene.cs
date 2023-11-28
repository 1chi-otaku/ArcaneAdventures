using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TriggerCutscene : MonoBehaviour, IDataPersistence
{
    private bool cutscenePlayed = false;
    public PlayableDirector cutsceneDirector; // ссылка на таймлайн катсцены
    public Canvas BlackBars;
    public PlayerControl playerControl;
    private Collider triggerCollider;


    private void Update()
    {
        if (cutscenePlayed && Input.GetKeyDown(KeyCode.F))
        {
            OnCutsceneEnd(cutsceneDirector);
        }
    }

    private void Start()
    {
        // Получаем компонент Collider при старте
        triggerCollider = GetComponent<Collider>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!cutscenePlayed)
            {
                BlackBars.gameObject.SetActive(true);
                cutsceneDirector.stopped += OnCutsceneEnd; // подписываемся на событие окончания воспроизведения
                cutsceneDirector.Play();
                playerControl.isMovementAllowed = false;
                cutscenePlayed = true;

                // Отключаем триггер (Collider) после активации
                if (triggerCollider != null)
                {
                    triggerCollider.enabled = false;
                }
            }
        }
    }

    private void OnCutsceneEnd(PlayableDirector director)
    {
        BlackBars.gameObject.SetActive(false);
        cutsceneDirector.stopped -= OnCutsceneEnd;
        playerControl.isMovementAllowed = true;
        cutsceneDirector.Stop();

    }

    public void LoadData(GameData data)
    {
        cutscenePlayed = data.IsOverviewCutscenePlayed;
    }

    public void SaveData(ref GameData data)
    {
        data.IsOverviewCutscenePlayed = cutscenePlayed;
    }
}
