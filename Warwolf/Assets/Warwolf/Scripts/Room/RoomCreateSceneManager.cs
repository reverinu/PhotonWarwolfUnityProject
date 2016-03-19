using UnityEngine;
using System.Collections;

public class RoomCreateSceneManager : MonoBehaviour {

    [SerializeField]
    Fade scene_fade = null;


	// Use this for initialization
	void Start () {
        scene_fade.FadeOut(1f);
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
