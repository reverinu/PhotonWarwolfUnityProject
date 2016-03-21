using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomCreateSceneManager : MonoBehaviour {

    [SerializeField]
    Fade scene_fade = null;// Scene入った時のフェードアウト用

    [SerializeField]
    RoomValuableManager room_valuable_manager;

    [SerializeField]
    InputField player_name_input = null;
    [SerializeField]
    InputField room_number_input = null;

    // Use this for initialization
    void Start () {
        scene_fade.FadeOut(1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void GameStartButtonPush()
    {
        if (player_name_input.text != null && room_number_input.text != null)
        {
            room_valuable_manager.GetComponent<RoomValuableManager>().player_name_text = player_name_input.GetComponent<InputField>().text;
            room_valuable_manager.GetComponent<RoomValuableManager>().room_number_text = room_number_input.GetComponent<InputField>().text;
            Debug.Log(room_valuable_manager.GetComponent<RoomValuableManager>().player_name_text + room_valuable_manager.GetComponent<RoomValuableManager>().room_number_text);
            Application.LoadLevel("RoomScene");
        }
    }

    public void BackButtonPush()
    {
        Debug.Log("Back Button Push !!");
        Application.LoadLevel("LaunchScene");
    }
}
