using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    public Animator anim;
    // Use this for initialization
    void Start () {

        anim.speed =0.5f;
        Debug.Log(anim.speed);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
