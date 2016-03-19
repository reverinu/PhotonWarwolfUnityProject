using UnityEngine;
using System.Collections;

public class RoomCreateSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BackButtonPush()
    {
        Debug.Log("Back Button Push !!");
        Application.LoadLevel("LaunchScene");
    }
}
