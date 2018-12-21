using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class middleEnemy_Attack_hit : MonoBehaviour {
    Animator anim;
    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄
    public bool hit_flag=false;
    private EnemyAttack_manager EnemyAttack_manager;
    public bool state=false;
    float timer=0;

    void middleBoss_hit()
    {
        hit_flag = true;
        Debug.Log("hit_flag=" + hit_flag);


    }


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        EnemyAttack_manager = GetComponent<EnemyAttack_manager>(); //與外部判斷是否fire做連結
    }
	
	// Update is called once per frame
	/*void Update () {
      
        if (state==false&&EnemyAttack_manager.normalhit_state==true) {
            timer +=Time.deltaTime;
            anim.SetBool("middle_enemy_normalhit_start", true);
            middleBoss_hit();

            if (timer>1f) {
                state = true;

            }


        }

        if (state == true)
        {

            anim.SetBool("middle_enemy_normalhit_start", false);


        }
    }*/
}
