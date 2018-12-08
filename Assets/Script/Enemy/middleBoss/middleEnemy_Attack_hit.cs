using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class middleEnemy_Attack_hit : MonoBehaviour {
    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄
    public bool hit_flag=false;

    void middleBoss_hit()
    {
        hit_flag = true;

    }


    // Use this for initialization
    void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Transform target = GameObject.FindGameObjectWithTag("main").transform;
    }
	
	// Update is called once per frame
	void Update () {
        middleBoss_hit();
        hit_flag = false;
	}
}
