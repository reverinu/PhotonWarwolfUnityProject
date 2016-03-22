using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomSceneManager : Photon.MonoBehaviour {

    [SerializeField]
    RoomValuableManager room_valuable_manager;
    

	// Use this for initialization
	void Start () {


        PhotonNetwork.ConnectUsingSettings("0.1"); // Photonへの接続
        PhotonNetwork.sendRate = 30; // 更新回数３０に設定
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnJoinedLobby()
    {
        // ルームのオプション設定
        RoomOptions room_options = new RoomOptions();
        room_options.maxPlayers = 16;

        if (room_valuable_manager.GetComponent<RoomValuableManager>().is_player_num == 1)
        {
            PhotonNetwork.CreateRoom(
                room_valuable_manager.GetComponent<RoomValuableManager>().room_number_text,
                room_options,
                null);
        }
        else if (room_valuable_manager.GetComponent<RoomValuableManager>().is_player_num > 1 && room_valuable_manager.GetComponent<RoomValuableManager>().is_player_num <= 16)
        {
            PhotonNetwork.JoinRoom(room_valuable_manager.GetComponent<RoomValuableManager>().room_number_text);
        }
        else
        {
            OnPhotonRandomJoinFailed();
        }
    }

    void OnPhotonRandomJoinFailed()
    {
        Application.LoadLevel("LaunchScene");
    }

    void OnJoinedRoom()
    {

    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
}
