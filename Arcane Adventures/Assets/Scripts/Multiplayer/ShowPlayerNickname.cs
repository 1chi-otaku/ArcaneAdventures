using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;


public class ShowPlayerNickname : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.Owner.NickName != null)
        {
            GetComponent<Text>().text = photonView.Owner.NickName;
            Debug.Log("��� ���������� � �����.");
        }
        else
        {
            Debug.Log("Null � photonView.Owner.NickName");
        }
    }
}
