using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ListItem : MonoBehaviour
{
    [SerializeField] Text textName;
    [SerializeField] InputField nickname;
    [SerializeField] Text textPlayerCount;
    public void SetInfo(RoomInfo info)
    {
        textName.text = info.Name;
        textPlayerCount.text = info.PlayerCount + "/" + info.MaxPlayers;
    }

    public void JoinToListRoom()
    {
        PhotonNetwork.JoinRoom(textName.text);
        if (nickname.text == "" || nickname.text == null)
        {
            PhotonNetwork.NickName = "User";
            Debug.Log("Установлен дефолтный ник.");
        }
        else
        {
            PhotonNetwork.NickName = nickname.text;
            Debug.Log("Установлен ник пользователя.");
        }
    }


}
