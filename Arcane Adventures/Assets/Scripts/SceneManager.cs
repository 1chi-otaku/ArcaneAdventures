using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{

    [Header("Menu Buttons")]

    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;

    private void Start()
    {
        if (!DataPersisteneManager.instance.HasGameData())
        {
            loadGameButton.interactable = false;
            ColorBlock colors = loadGameButton.colors;
            colors.normalColor = Color.gray;
            loadGameButton.colors = colors;
        }
    }
    public void ChangeScene(string scene)
    {
        Time.timeScale = 1f;
        Debug.Log("New Game: " + scene);

        DataPersisteneManager.instance.NewGame();

        SceneManager.LoadSceneAsync(scene);
    }

    public void CloseUnityApplication()
    {
        Application.Quit();
    }

    public void Load()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("GameScene2");
    }

    public void Return()
    {
        Time.timeScale = 1f;
        DataPersisteneManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Menu");
    }
}
