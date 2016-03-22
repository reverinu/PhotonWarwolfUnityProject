using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomJoinSceneManager : Photon.MonoBehaviour {


    private PhotonView photonview;
    [SerializeField]
    Component photonview_component;

    [SerializeField]
    Fade scene_fade = null;

    [SerializeField]
    RoomValuableManager room_valuable_manager;

    [SerializeField]
    InputField player_name_input = null;
    [SerializeField]
    InputField room_number_input = null;

    // Use this for initialization
    void Start () {
        photonview = PhotonView.Get(photonview_component);
        scene_fade.FadeOut(1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void GameStartButtonPush()
    {
        if (player_name_input.GetComponent<InputField>().text != "入力してください" && room_number_input.GetComponent<InputField>().text != "入力してください")
        {
            
            //PhotonNetwork.JoinRoom(player_name_input.GetComponent<InputField>().text);
            PhotonNetwork.JoinRandomRoom();
            StartCoroutine(ButtonPushMethod(1f, () =>
            {
                Debug.Log("Join Button Push !!");
                GameObject room_valuable_manager_object = PhotonNetwork.Instantiate("RoomValuableManager", Vector3.zero, Quaternion.identity, 0);



                //if (room_valuable_manager.GetComponent<RoomValuableManager>().is_player_num > 0)
                //{
                //    room_valuable_manager.GetComponent<RoomValuableManager>().is_player_num++;
                //}
                if (photonview.isMine)
                {
                    room_valuable_manager.GetComponent<RoomValuableManager>().player_name_text = player_name_input.GetComponent<InputField>().text;
                }
                room_valuable_manager.GetComponent<RoomValuableManager>().room_number_text = room_number_input.GetComponent<InputField>().text;
                Debug.Log(room_valuable_manager.GetComponent<RoomValuableManager>().player_name_text + room_valuable_manager.GetComponent<RoomValuableManager>().room_number_text);


                Application.LoadLevel("RoomScene");
            }));



        }
    }

    void OnPhotonRandomJoinFailed()
    {
        Application.LoadLevel("LaunchScene");
    }

    public void BackButtonPush()
    {
        Debug.Log("Back Button Push !!");
        Application.LoadLevel("LaunchScene");
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    private IEnumerator ButtonPushMethod(float waitTime, System.Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
