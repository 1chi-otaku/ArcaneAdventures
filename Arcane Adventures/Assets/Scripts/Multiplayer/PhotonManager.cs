using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Cinemachine;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] string region; 
    [SerializeField] InputField nickname;
    [SerializeField] GameObject point;
    [SerializeField] InputField roomName;
    [SerializeField] ListItem roomItem;
    [SerializeField] Transform roomContent;

    private GameObject player;
    private Transform spawnpoint;

    [SerializeField] GameObject player_prefab;
    List<RoomInfo> allRooms = new List<RoomInfo>();

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion(region);
        spawnpoint = point.transform;
        Vector3 objectPosition = spawnpoint.position;

        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate(player_prefab.name, objectPosition, Quaternion.identity);
            Debug.Log("Пользователь подключен.");
        }
        else
        {
            Debug.Log("Пользователь не подключен.");
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Вы подключились к: " + PhotonNetwork.CloudRegion);

        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Вы отключены от сервера.");
    }

    public void CreateRoomButton()
    {
        if(!PhotonNetwork.IsConnected)
        {
            return;
        }
        if(roomName.text == null || roomName.text == "")
        {
            roomName.text = "unnamed";
        }

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(roomName.text, roomOptions, TypedLobby.Default);
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

    public override void OnCreatedRoom()
    {
        Debug.Log("Создана комната " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Не удалось создать комнату " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo roomInfo in roomList)
        {
            for (int i = 0; i < allRooms.Count; i++)
            {
                if (allRooms[i].masterClientId == roomInfo.masterClientId)
                {
                    return;
                }
            }
            ListItem listItem = Instantiate(roomItem, roomContent);
            if(listItem != null)
            {
                listItem.SetInfo(roomInfo);
                allRooms.Add(roomInfo);
            }

        }
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene1");
    }

    public void JoinButton()
    {
        if (roomName.text != "")
        {
            PhotonNetwork.JoinRoom(roomName.text);
        }

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

    public void LeaveButton()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("Leave room.");
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Destroy(player.gameObject);
        Debug.Log("Go to menu.");
    }
}
