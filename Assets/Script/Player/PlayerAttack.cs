using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    bool attack;
    Animator playerAnim;
    // Use this for initialization
    void Start () {
        playerAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        GetKey();

        //Animating()
    }

    void Attack()
    {

    }

    void GetKey()
    {
        attack = Input.GetButtonDown("Attack");
    }

    //void Animating()
    //{
    //    if()
    //}
}
