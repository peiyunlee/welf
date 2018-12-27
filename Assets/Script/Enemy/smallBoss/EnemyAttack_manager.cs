using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack_manager : MonoBehaviour {
    Animator anim;
    public Transform main;//要跟随英雄
     float attackDis = 40f;//達到此距離開始攻擊
     float attackDis_shock = 40f;//達到此距離開始攻擊_shock
    public static bool bighit_state_right = false;
    public static bool bighit_state_left = false;
    public static bool normalhit_state = false;
    public static bool shockhit_state = false;
    private middleEnemy_movement movement;
    private rightBulletController right;
    private leftBulletController left;
    private int change_attack ;
    // Use this for initialization
   
    int test = 1;
    float timer=0;
    void Start()
    {
        main = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        movement = GetComponent<middleEnemy_movement>();
        right = GetComponent<rightBulletController>();
        left = GetComponent<leftBulletController>();

    }

    // Update is called once per 
    public void refresh()
    {
        right.state = false;
        left.state = false;

    }

     public void bighit()
    {


        if (Vector2.Distance(transform.position, main.position) <= attackDis && (main.position.x - transform.position.x > 0))
        {
            timer += Time.deltaTime;
            bighit_state_right = true;
            
            if (timer > 0f && timer < 1f)
            {
                anim.SetBool("middle_enemy_bighit_start", true);
            }

            

            if (timer > 2f )
            {
                anim.SetBool("middle_enemy_bighit_start", false);
                movement.bighit_state = false;
            }



        }
        if (Vector2.Distance(transform.position, main.position) <= attackDis && (main.position.x - transform.position.x < 0))//跟随距离
        {
            timer += Time.deltaTime;
            bighit_state_left = true;
           
            if (timer > 0f && timer < 1f)
            {
                anim.SetBool("middle_enemy_bighit_start", true);
            }

         

            if (timer > 2f)
            {
                anim.SetBool("middle_enemy_bighit_start", false);
                movement.bighit_state = false;
            }
        }

    }



  
}
