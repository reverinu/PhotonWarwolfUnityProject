using UnityEngine;
using System.Collections;

public class LaunchSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    [SerializeField]
    Fade scene_fade = null;

    public void RoomCreateButtonPush()
    {
        scene_fade.FadeIn(1f);
        StartCoroutine(ButtonPushMethod(1f, () =>
        {
            Debug.Log("Create Button Push !!");
            Application.LoadLevel("RoomCreateScene");
        }));
    }

    public void RoomJoinButtonPush()
    {
        scene_fade.FadeIn(1f);
        StartCoroutine(ButtonPushMethod(1f, () =>
        {
            Debug.Log("Join Button Push !!");
            Application.LoadLevel("RoomJoinScene");
        }));
    }


    private IEnumerator ButtonPushMethod(float waitTime, System.Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

    

}
