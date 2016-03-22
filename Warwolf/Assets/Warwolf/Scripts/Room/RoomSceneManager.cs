using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomSceneManager : Photon.MonoBehaviour {

    [SerializeField]
    RoomValuableManager room_valuable_manager;
    

    [SerializeField]
    Text room_number_text;
    

	// Use this for initialization
	void Start () {

        GameObject room_valuable_manager_object = PhotonNetwork.Instantiate("RoomValuableManager", Vector3.zero, Quaternion.identity, 0);

        room_valuable_manager.GetComponent<RoomValuableManager>().is_player_num++;
    }
	
	// Update is called once per frame
	void Update () {
        room_number_text.GetComponent<Text>().text = room_valuable_manager.GetComponent<RoomValuableManager>().is_player_num + "人";
	}

    void OnJoinedLobby()
    {
        
        
    }

    void OnPhotonRandomJoinFailed()
    {
        Application.LoadLevel("LaunchScene");
    }

    void OnJoinedRoom()
    {
        //GameObject room_valuable_manager = PhotonNetwork.Instantiate("RoomValuableManager", Vector3.zero, Quaternion.identity, 0);
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
}
