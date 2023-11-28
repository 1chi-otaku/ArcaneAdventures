using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class endtimeline : MonoBehaviour
{
    private PlayableDirector playableDirector;
    public string LoadScene;

    private void Start()
    {
        // �������� ��������� PlayableDirector �� ���� �������
        playableDirector = GetComponent<PlayableDirector>();

        // ������������� �� ������� ���������� ���������
        if (playableDirector != null)
        {
            playableDirector.stopped += OnTimelineStopped;
        }
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        // ������������� �����
        SceneManager.LoadScene(LoadScene);

    }
}
