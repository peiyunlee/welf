using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Enemymovement : MonoBehaviour {
    public Animator anim;
    private littleEnemy_Attack_shock shock;
    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄


    bool border_tag=false;//是否碰到限制範圍
    float followDis = 30f;//達到此距離開始跟隨
    float attackDis = 20f;
    public float idle_speed = 10f;//移動速度
    public float follow_speed = 15f;//跟隨速度
    private EnemyHealth enemyHealth;

   public  float timer = 0;

    float timer_dead = 0;

    PlayerHealth playerHealth;
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
        main = GameObject.FindGameObjectWithTag("Player").transform;
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyHealth = GetComponent<EnemyHealth>();
        shock = GetComponent<littleEnemy_Attack_shock>();
        anim = GetComponent<Animator>();
        Vector2 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }


    float initialx;

    bool stat_dead = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            /*playerHealth.TakeDamage(1);*/

        }
    }

    void resetanim()
    {
        Destroy(this.gameObject);
        anim.SetBool("littleEnemy_hurt", false);
        CancelInvoke("resetanim");
    }


    void Update()
    {
        if (stat_dead == false&& enemyHealth.isDead)
        {
            anim.SetBool("littleEneny_dead", true);
            stat_dead = true;
        }

        if (enemyHealth.isDead)
        {
            timer_dead += Time.deltaTime;
            Vector2 transformValue = new Vector2(0, 0);
            playerRigidbody.velocity = transformValue;
            Invoke("resetanim", 1f);

            


        }
        else {

            if ((Vector2.Distance(transform.position, main.position) <= followDis)) {

                if ((Vector2.Distance(transform.position, main.position) <= attackDis))
                {


                    if (((main.position.x > transform.position.x) || shock.State_right == true) && shock.State_left == false)
                    {
                        shock.State_right = true;
                        timer += Time.deltaTime;
                        shock.normalAttack_hit_right();
                     
                        anim.SetBool("littleEnemy_hit_left",true);


                    }


                    else if (((main.position.x < transform.position.x) || shock.State_left == true) && shock.State_right == false)
                    {
                        shock.State_left = true;
                        timer += Time.deltaTime;
                        shock.normalAttack_hit_left();
                       
                        anim.SetBool("littleEnemy_hit_left", true);
                    }


                }

                else if((Vector2.Distance(transform.position, main.position) > attackDis))
                {

                    follow();
                }
            }
                
            
            else if((Vector2.Distance(transform.position, main.position) > attackDis))
            {
               anim.SetBool("littleEnemy_hit_left", false);
                idle();


            }
        
        }

    }
   
}

