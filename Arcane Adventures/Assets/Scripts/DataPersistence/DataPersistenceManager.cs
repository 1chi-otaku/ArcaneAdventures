using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataPersisteneManager : MonoBehaviour
{
    // Текущее состояние нашей игры.

    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    public static DataPersisteneManager instance { get; private set; }
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Каким-то образом тут два инстанса DataPersistanceManager, но как?");
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData= new GameData();
    }

    public void LoadGame()
    {
        //Метод загружает сохранненые данные из файла используя data handler
        this.gameData = dataHandler.Load();


        //Если данных для загрузки нет, инициализировать новую игру.
        if(this.gameData == null)
        {
            Debug.Log("Данные для загрузки не найдены. Данные инициализируются дефолтом");
            NewGame();
        }
        // Запушить загруженные ланные во все другие скрипты
        foreach (IDataPersistence dataPersistenceObj  in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        
    }

    public void SaveGame()
    {
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
}
