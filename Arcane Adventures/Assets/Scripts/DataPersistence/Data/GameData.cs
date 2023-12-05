using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{

    public bool IsOverviewCutscenePlayed; // Показывалась ли игроку начальная катцена.
    public bool IsLunQuestCompleted; //Выполнился ли квест на убийство 5 мобов, тригерится, когда поговорил с Лунем.
    public Vector3 playerPosition; // Позиция игрока
    public int PlayerHp;
    public int KilledSkeleons;

    public Dictionary<string, bool> SkelletonState;


    //Значения, которые определяются в этом конструкторе будут дефолтными значениями.
    //Игра будет начинаться с этих значений, если нет данных для загрузки.
    public GameData()
    {
        IsOverviewCutscenePlayed = false;
        IsLunQuestCompleted = false;
        playerPosition = new Vector3((float)10.47, (float)0.22, (float)5.02);
        PlayerHp = 100;
        KilledSkeleons = 0;
        SkelletonState = new Dictionary<string, bool>();

    }



}
