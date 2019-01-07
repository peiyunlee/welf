using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayDialog : MonoBehaviour {
    bool faceright;
    bool nowfaceright;
    public float length;
    // Use this for initialization
    void Start () {
        if (gameObject.name == "BossSayDialog")
        {
            faceright = false;
        }
        else if (gameObject.name == "PlayerSayDialog")
        {
            faceright = true;
        }
        faceright = true;
        nowfaceright = faceright;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 v;
        v = this.gameObject.transform.localScale;
        if(gameObject.name== "BossSayDialog")
        {
            faceright = middleEnemy_movement.faceright;
        }
        else if (gameObject.name == "PlayerSayDialog")
        {
            faceright = PlayerMovement.faceRight;
        }
        
        if (nowfaceright!= faceright)  //轉向了
        {
            v.x *= -1f;
            this.gameObject.transform.localScale = v;
            gameObject.transform.position += new Vector3(length, 0f, 0);
            nowfaceright = faceright;
        }
	}
}
