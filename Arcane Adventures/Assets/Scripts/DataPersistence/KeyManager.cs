using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyManager : MonoBehaviour
{
    int platformerCompleted;
    int fifteenCompleted;
    int labyCompleted;

    int keys;


    public int KeysCount
    {
        get { return keys; }
    }

    void OnEnable()
    {
        // Подключаем метод OnSceneLoaded к событию загрузки сцены
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Отключаем метод OnSceneLoaded от события загрузки сцены при выходе из сцены
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        keys = 0;
        platformerCompleted = PlayerPrefs.GetInt("PlatformerCompleted");
        fifteenCompleted = PlayerPrefs.GetInt("FifteenCompleted");
        labyCompleted = PlayerPrefs.GetInt("LabyCompleted");

        Debug.Log("Pltf - " + platformerCompleted);
        Debug.Log("15 - " + fifteenCompleted);
        Debug.Log("Laby - " + labyCompleted);


        if(platformerCompleted == 1 && PlayerPrefs.GetInt("WasPlatformerCompleted") != 1)
        {
            //PlayCutscene
            PlayerPrefs.SetInt("WasPlatformerCompleted", 1);
        }
        if (fifteenCompleted == 1 && PlayerPrefs.GetInt("WasFifteenCompleted") != 1)
        {
            //PlayCutscene
            PlayerPrefs.SetInt("WasFifteenCompleted", 1);
        }
        if (labyCompleted == 1 && PlayerPrefs.GetInt("WasLabyCompleted") != 1)
        {
            //PlayCutscene
            PlayerPrefs.SetInt("WasLabyCompleted", 1);
        }

        if(platformerCompleted != 0)
        {
            keys++;
        }
        if(fifteenCompleted != 0)
        {
            keys++;
        }
        if(labyCompleted != 0)
        {
            keys++;
        }

        Debug.Log("Keys - " + keys);

    }

}