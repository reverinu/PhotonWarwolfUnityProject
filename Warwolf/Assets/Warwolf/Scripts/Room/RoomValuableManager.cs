using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomValuableManager : Photon.MonoBehaviour {

    public string player_name_text = null;
    public string room_number_text = null;
    public int is_player_num = 0;// 1がルームマスター

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //データの送信
            //stream.SendNext(GetComponent<Renderer>().material.color.r);
            //stream.SendNext(GetComponent<Renderer>().material.color.g);

            //stream.SendNext(player_name_text);
            //stream.SendNext(room_number_text);
            stream.SendNext(is_player_num);
        }
        else
        {
            //データの受信
            //float r = (float)stream.ReceiveNext();
            //float g = (float)stream.ReceiveNext();
            //GetComponent<Renderer>().material.color = new Vector4(r, g, b, a);

            is_player_num = (int)stream.ReceiveNext();

        }
    }
}
