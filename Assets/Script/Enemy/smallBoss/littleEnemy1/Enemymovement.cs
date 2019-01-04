using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Enemymovement : MonoBehaviour {
    public Animator anim;
    private littleEnemy_Attack_shock shock;
    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄
    public Transform count;

    bool border_tag=false;//是否碰到限制範圍
    float followDis = 20f;//達到此距離開始跟隨
    float attackDis = 15f;
    public float idle_speed = 10f;//移動速度
    public float follow_speed = 15f;//跟隨速度
    private EnemyHealth enemyHealth;
    public  float timer = 0;
    PlayerHealth playerHealth;
    public Enemy_count countAllEnemy1;
    bool detectCharac;
    float scale = 0.7f;

    //判斷轉向
    void detectScale()
    {
        if (main.position.x-transform.position.x>0)
        {
            this.gameObject.transform.localScale = new Vector3(-scale, scale, 1f);

        }

        else
        {
           
                this.gameObject.transform.localScale = new Vector3(scale, scale, 1f);

            


        }

    }
    void detectCharacFunc()//判斷是否位於同一平台
    {
        if ((main.position.y - transform.position.y) <= 3f && (main.position.y - transform.position.y) >= -10f)
        {

            detectCharac = true;
        }
        else
        {
            detectCharac = false;

        }

    }

    void detectIdle()
    {
        if (idle_speed>0)
        {
            this.gameObject.transform.localScale = new Vector3(-scale, scale, 1f);

        }
        else
        {

            this.gameObject.transform.localScale = new Vector3(scale, scale, 1f);

        }


    }


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
        detectIdle();
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
        main = GameObject.FindGameObjectWithTag("Player").transform;
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyHealth = GetComponent<EnemyHealth>();
        shock = GetComponent<littleEnemy_Attack_shock>();
        anim = GetComponent<Animator>();
        Vector2 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
        count = GameObject.FindGameObjectWithTag("count").transform;
        countAllEnemy1 = count.GetComponent<Enemy_count>();
    }


    float initialx;

    bool stat_dead = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            playerHealth.TakeDamage(1);

        }
    }

    void resetanim()
    {
       
        Destroy(this.gameObject);
        CancelInvoke("resetanim");
    }

    bool startnewanim = true;
    public void animatestate(int state)
    {
     

            switch (state)
            {

                case 1:  //hit anim
                    anim.SetBool("littleEnemy_hit", true);
                    anim.SetBool("littleEnemy_idle", false);
                    break;

                case 2: //idle anim
                    anim.SetBool("littleEnemy_hit", false);
                    anim.SetBool("littleEnemy_idle", true);
                    break;
                
        }
            

    }
    
    

    void Update()
    {

        detectCharacFunc();

        if (enemyHealth.isDead)
        {
            anim.SetBool("littleEneny_dead", true);
            countAllEnemy1.littleEnemy1_count--;
            Vector2 transformValue = new Vector2(0, 0);
            playerRigidbody.velocity = transformValue;
            Invoke("resetanim", 1f);

        }
        else {

            if ((Vector2.Distance(transform.position, main.position) <= followDis)&& detectCharac == true) {
                detectScale();

                if ((Vector2.Distance(transform.position, main.position) <= attackDis))
                {
                    detectScale();

                    if (((main.position.x > transform.position.x) || shock.State_right == true) && shock.State_left == false && detectCharac == true)
                    {
                        shock.State_right = true;
                        timer += Time.deltaTime;
                        shock.normalAttack_hit_right();
                        animatestate(1);
                        


                    }


                    else if (((main.position.x < transform.position.x) || shock.State_left == true) && shock.State_right == false && detectCharac == true)
                    {
                        shock.State_left = true;
                        timer += Time.deltaTime;
                        shock.normalAttack_hit_left();
                        animatestate(1);
                        
                    }


                }

                else if((Vector2.Distance(transform.position, main.position) > attackDis) && detectCharac == true)
                {
                    detectScale();
                    follow();
                    animatestate(2);
                }
            }
                
            
            else if((Vector2.Distance(transform.position, main.position) > attackDis))
            {
               
                idle();
               animatestate(2);


            }
        
        }

    }
   
}

