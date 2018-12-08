using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleEnemy_Attack_bighit : MonoBehaviour {
    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄

    // Use this for initialization
    void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Transform target = GameObject.FindGameObjectWithTag("main").transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
