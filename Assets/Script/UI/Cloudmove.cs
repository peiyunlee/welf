using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloudmove : MonoBehaviour {
    public float fstartx;
    float fturnx;
    bool hasinstantiate;
    Vector3 parentposition;
    // Use this for initialization
    void Start () {
        hasinstantiate = false;
        fturnx = -205f;
    }

    // Update is called once per frame
    void Update () {
        gameObject.transform.position -=new Vector3( 0.05f,0f,0f);
        Debug.Log(gameObject.transform.position);
        if (gameObject.transform.position.x < fturnx && !hasinstantiate)
        {
            hasinstantiate = true;
            gameObject.transform.position= new Vector3(fstartx, -0.3f, 69.7f);
            Debug.Log("aa");
            hasinstantiate = false;
        }
	}
}
