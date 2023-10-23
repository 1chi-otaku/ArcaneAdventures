using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void ChangeScene(string scene)
    {
        Debug.Log("�����: " + scene);
        SceneManager.LoadScene(scene);
    }

    public void CloseUnityApplication()
    {
        Application.Quit();
    }
}
