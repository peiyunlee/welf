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
   
    private int change_attack ;
    // Use this for initialization
   
    int test = 1;
    float timer=0;
    void Start()
    {
        anim = GetComponent<Animator>();
      

    }

    // Update is called once per 

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

            

            if (timer > 2f && timer < 3f)
            {
                anim.SetBool("middle_enemy_bighit_start", false);
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

         

            if (timer > 2f && timer < 3f)
            {
                anim.SetBool("middle_enemy_bighit_start", false);
            }
        }

    }



    void Update () {//記得加swithcase後 所有enemymovement的state全都要refresh


        //bighit開始攻擊

      /*  if (Vector2.Distance(transform.position, main.position) <= attackDis && (main.position.x - transform.position.x > 0))
        {
            timer += Time.deltaTime;
            bighit_state_right = true;

            if (timer > 0f && timer < 1f)
            {
                anim.SetBool("middle_enemy_bighit_start", true);
            }

            

            if (timer > 2f && timer < 3f)
            {
                anim.SetBool("middle_enemy_bighit_start", false);
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

           

            if (timer > 2f && timer < 3f)
            {
                anim.SetBool("middle_enemy_bighit_start", false);
            }
        }*/

        //normalhit
        /*
        if (Vector2.Distance(transform.position, main.position) <= attackDis && (main.position.x - transform.position.x > 0))
        {
            Debug.Log("no");
            normalhit_state = true;
           
       }*/

        //shockhit

        /*if (Vector2.Distance(transform.position, main.position) <= attackDis_shock && (main.position.x - transform.position.x > 0))
        {
            shockhit_state = true;
            

        }*/




    }

}
