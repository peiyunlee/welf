using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welf2 : SkillSet {
    public int moveSpeed = 5;

    //主角相關
    GameObject player;
    Animator playAnim;
    PlayerMovement playerMovement;
    Rigidbody2D playerRigidbody;
    Transform playerTrans;

    //水精靈相關
    Animator welfAnim;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        playAnim = player.GetComponent<Animator>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerTrans = player.transform;

        welfAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        GetKey();
	}
    void GetKey()
    {
        keySkill = Input.GetButtonDown("Skill");
    }
}
