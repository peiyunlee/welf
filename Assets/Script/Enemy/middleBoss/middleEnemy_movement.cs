using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleEnemy_movement : MonoBehaviour {
    public Animator anim;
    private middleEnemy_Attack_shock shock;
    private middleEnemy_Attack_hit hit;
    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄


    bool border_tag = false;//是否碰到限制範圍
    float followDis = 30f;//達到此距離開始跟隨
    float attackDis = 20f;
    public float idle_speed = 20f;//移動速度
    public float follow_speed = 15f;//跟隨速度
    private middleEnemy_health enemyHealth;

    public float timer = 0;

    float timer_dead = 0;


    //跟隨函式
    void follow()
    {
        //當於怪物的右側
        if (Vector2.Distance(transform.position, main.position) <= followDis && (main.position.x - transform.position.x > 0))//跟随距离
        {

            Vector2 transformValue = new Vector2(10, 0);
            playerRigidbody.velocity = transformValue;

        }

        //當於怪物的左側

        if (Vector2.Distance(transform.position, main.position) <= followDis && (main.position.x - transform.position.x < 0))//跟随距离
        {
               
            Vector2 transformValue = new Vector2(-10, 0);
            playerRigidbody.velocity = transformValue;


        }
    }


    //怪物idle狀態
    int i = 0;
    void idle()
    {
        timer += Time.deltaTime;
        Vector2 transformValue = new Vector2(idle_speed, 0);
        i++;
        playerRigidbody.velocity = transformValue;
        if (i == 100)
        {
            Vector2 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            idle_speed = idle_speed * -1;
            i = 0;
        }
        /*Debug.Log(i);*/

        /*
        Vector2 transformValue = new Vector2(idle_speed, 0);

        playerRigidbody.velocity = transformValue;
        if (border_tag == true)
        {

            idle_speed = idle_speed * -1;

            border_tag = false;
        }


    */

    }


    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Transform target = GameObject.FindGameObjectWithTag("main").transform;
        enemyHealth = GetComponent<middleEnemy_health>();
        shock = GetComponent<middleEnemy_Attack_shock>();
        hit = GetComponent<middleEnemy_Attack_hit>();
        anim = GetComponent<Animator>();
        Vector2 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }


    float initialx;
    bool stat_dead = false;
    int attack_sytle;
    float attack_timer = 0;
    void Update()
    {
     
        /* if (stat_dead == false && enemyHealth.isDead)
         {
             anim.SetBool("littleEneny_dead", true);
             stat_dead = true;
         }*/

        /* if (enemyHealth.isDead)
         {
             timer_dead += Time.deltaTime;
             Vector2 transformValue = new Vector2(0, 0);
             playerRigidbody.velocity = transformValue;


             if (timer_dead > 1f)
             {
                 Destroy(this.gameObject);

             }


         }
         else
         {*/




        if ((Vector2.Distance(transform.position, main.position) <= followDis))
            {

                if ((Vector2.Distance(transform.position, main.position) <= attackDis))
                {
              
                attack_timer += Time.deltaTime;
                if ((int)attack_timer%4==0&& shock.State_left == false && shock.State_right == false&&hit.normalhit_state==false)
                {
                    attack_sytle = Random.Range(1, 3);

                }
               /* Debug.Log("timer="+(int)attack_timer);*/
                Debug.Log("attack_style="+attack_sytle);
               /* Debug.Log("shock.State_left=" + shock.State_left);
                Debug.Log(" shock.State_right=" + shock.State_right);*/
                /*Debug.Log("hit.normalhit_state=" + hit.normalhit_state);*/

                switch (attack_sytle)
                {
                      
                    case 1:

                        if (shock.State_left == false && shock.State_right == false)
                        {
                            if (Vector2.Distance(transform.position, main.position) <= attackDis && (main.position.x - transform.position.x > 0))
                            {
                                anim.SetBool("middle_enemy_normalhit_start", true);
                                hit.middleBoss_hit();



                            }
                            else if (Vector2.Distance(transform.position, main.position) <= attackDis && (main.position.x - transform.position.x < 0))
                            {
                                anim.SetBool("middle_enemy_normalhit_start", true);
                                hit.middleBoss_hit();

                            }
                            break;

                        }


                        break;

                    case 2:
                      
                            if (((main.position.x > transform.position.x) || shock.State_right == true) && shock.State_left == false&& hit.normalhit_state == false)
                            {
                                shock.State_right = true;
                                timer += Time.deltaTime;
                                shock.normalAttack_hit_right();

                                anim.SetBool("middle_enemy_shock_start ", true);


                            }


                            else if (((main.position.x < transform.position.x) || shock.State_left == true) && shock.State_right == false && hit.normalhit_state == false)
                            {
                                shock.State_left = true;
                                timer += Time.deltaTime;
                                shock.normalAttack_hit_left();

                                anim.SetBool("middle_enemy_shock_start ", true);
                            }

                        
                      
                        break;
                  
                        
                  


                }




                //中怪普攻
                /*
                if (Vector2.Distance(transform.position, main.position) <= attackDis && (main.position.x - transform.position.x > 0))
                {
                    anim.SetBool("middle_enemy_normalhit_start", true);


                }
                else if (Vector2.Distance(transform.position, main.position) <= attackDis && (main.position.x - transform.position.x < 0))
                {
                    anim.SetBool("middle_enemy_normalhit_start", true);
                   


                }*/

                //中怪衝擊
                /*  if (((main.position.x > transform.position.x) || shock.State_right == true) && shock.State_left == false)
                  {
                      shock.State_right = true;
                      timer += Time.deltaTime;
                      shock.normalAttack_hit_right();

                      anim.SetBool("middle_enemy_shock_start ", true);


                  }


                  else if (((main.position.x < transform.position.x) || shock.State_left == true) && shock.State_right == false)
                  {
                      shock.State_left = true;
                      timer += Time.deltaTime;
                      shock.normalAttack_hit_left();

                      anim.SetBool("middle_enemy_shock_start ", true);
                  }
                  */

            }

                else if ((Vector2.Distance(transform.position, main.position) > attackDis))
                {

                    follow();
                }
            }


            else if ((Vector2.Distance(transform.position, main.position) > attackDis))
            {
                anim.SetBool("middle_enemy_shock_start ", false);
            anim.SetBool("middle_enemy_normalhit_start", false);
            idle();


            }

      



    }

}
