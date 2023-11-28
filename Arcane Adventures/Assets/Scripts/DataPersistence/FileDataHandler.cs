using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        //Эта функция парсит строку расположения файла для всех ОС. Как-то...
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //Десериализация JSON в С# объект.
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

            }
            catch(Exception e)
            {
                Debug.LogError("Возник трабл при загрузки данных из файлф" + fullPath + "\n" + e);
            }
        }
        return loadedData;

    }

    public void Save(GameData data)
    {
        //Эта функция парсит строку расположения файла для всех ОС. Как-то...
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            //Создать директорию, если она не существует на компе.
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //Сериализация gameData в JSON
            string dataToStore = JsonUtility.ToJson(data,true);

            //Записать файл в файловую систему
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("Возник трабл при записи данных для сохранения в файл" + fullPath + "\n" + e);

        }
    }
}
