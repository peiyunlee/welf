using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Enemymovement : MonoBehaviour {
    private littleEnemy_Attack_shock shock;
    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄


    bool border_tag=false;//是否碰到限制範圍
    float followDis = 20f;//達到此距離開始跟隨
    float attackDis = 20f;
    public float idle_speed = 10f;//移動速度
    public float follow_speed = 15f;//跟隨速度
    private EnemyHealth enemyHealth;

   public  float timer = 0;
    
    //判斷是否碰到所限制的範圍
  /*  void OnCollisionEnter2D(Collision2D border)
    {
        Debug.Log("trigger");
        border_tag = true;
        if (border.gameObject.CompareTag("Player"))
        {
            Debug.Log("trigger");
           

        }
     }**/

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
    int i=0;
    void idle()
    {
        timer += Time.deltaTime;
        Vector2 transformValue = new Vector2(idle_speed, 0);
        i++;
        playerRigidbody.velocity = transformValue;
        if (i==100)
        {

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
        enemyHealth = GetComponent<EnemyHealth>();
        shock = GetComponent<littleEnemy_Attack_shock>();
        
    }


    float initialx;

   
  
    void Update()
    {
       /* Debug.Log("shock.State_right=" + shock.State_right);
        Debug.Log("shock.State_left=" + shock.State_left);*/
        Debug.Log(Vector2.Distance(transform.position, main.position));
        if (enemyHealth.isDead)
        {
            Vector2 transformValue = new Vector2(0, 0);
            playerRigidbody.velocity = transformValue;

        }
        else {
          
            /*if (Vector2.Distance(transform.position, main.position) <= followDis)*/
            {
                

                if ((Vector2.Distance(transform.position, main.position)<=attackDis))
                {
                 
                 
                    if (((main.position.x> transform.position.x)|| shock.State_right==true)&& shock.State_left==false) {
                        shock.State_right = true;
                        shock.timer = 0;
                        timer += Time.deltaTime;
                        shock.normalAttack_hit_right();
                       

                    }
                   
                   
                    else if(((main.position.x < transform.position.x)||shock.State_left==true)&& shock.State_right==false)
                    {
                        shock.State_left = true;
                        shock.timer = 0;
                        timer += Time.deltaTime;
                        shock.normalAttack_hit_left();
                       
                    }
                   

                }

               /* else (Vector2.Distance(transform.position, main.position) > attackDis)
                {
                    Debug.Log("follow");
                    follow();
                    initialx = transform.position.x;


                }*/

             }
         /*   else
            {
                idle();


            }*/

        }

    }
   
}

