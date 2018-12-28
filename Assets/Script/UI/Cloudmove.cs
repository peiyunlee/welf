using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloudmove : MonoBehaviour {
    GameObject currentcloud;
    GameObject nextcloud;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position -=new Vector3( 0.1f,0f,0f);
	}
}
