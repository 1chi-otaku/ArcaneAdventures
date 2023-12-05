using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonManager : MonoBehaviour
{
    public SerializableDictionary<string, bool> SkelletonState;


    void Start()
    {
        GetSkeletonIds();
        Debug.Log("SkelletonState count: " + SkelletonState.Count);
    }
    // Метод для получения идентификаторов скелетов
    public string[] GetSkeletonIds()
    {
        // Находим все объекты с компонентом EnemyDamage
        EnemyDamage[] skeletons = FindObjectsOfType<EnemyDamage>();

        // Создаем массив для хранения идентификаторов
        string[] skeletonIds = new string[skeletons.Length];

        // Заполняем массив идентификаторами
        for (int i = 0; i < skeletons.Length; i++)
        {
            skeletonIds[i] = skeletons[i].id;
        }

        return skeletonIds;
    }
}
