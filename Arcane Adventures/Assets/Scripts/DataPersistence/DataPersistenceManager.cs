using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersisteneManager : MonoBehaviour
{
    // Текущее состояние нашей игры.

    [Header("Debbuging")]
    [SerializeField] private bool initializeDataIfNull = false;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    public static DataPersisteneManager instance { get; private set; }
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;


   private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        Debug.Log("On Scene Loaded");
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    private void OnSceneUnloaded(UnityEngine.SceneManagement.Scene scene )
    {
        Debug.Log("On Scene UnLoaded");
        SaveGame();
    }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Каким-то образом тут два инстанса DataPersistanceManager, но как?");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    public void NewGame()
    {
        this.gameData= new GameData();
    }

    public void LoadGame()
    {

        if(this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }
        //Метод загружает сохранненые данные из файла используя data handler
        this.gameData = dataHandler.Load();


        //Если данных для загрузки нет, инициализировать новую игру.
        if(this.gameData == null)
        {
            Debug.Log("Данные для загрузки не найдены. Нужно начать новую игру");
            return;
        }
        // Запушить загруженные ланные во все другие скрипты
        foreach (IDataPersistence dataPersistenceObj  in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        
    }

    public void SaveGame()
    {

        if(this.gameData == null)
        {
            Debug.LogWarning("No data was found. A new Game needs to be started before data can be saved");
            return;
        }
        // - pass the game to other scripts so they can update it.

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        // - save that data to a file using the data handler.

        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        // FindObjectsofType takes in an optional boolean to include inactive gameobjects
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return this.gameData != null;
    }
}
