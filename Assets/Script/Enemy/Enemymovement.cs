using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Enemymovement : MonoBehaviour {

    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄
    public Transform enemyBorderRight;//要跟随英雄
    public Transform enemyBorderLeft;
    public Transform trackCharacterDistance;
    private CharacterController con;//怪物的角色控制器
    bool border_tag=false;
    bool reset_border_tag = false;
    bool enemy_long_tag = false;
    bool border_left_tag = false;

    public float followDis = 100f;//达到这个距离开始跟随
    public float speed = 10f;
    private float enemyposition;
    public int enemyinitiallocat;
    void OnTriggerEnter2D(Collider2D border)
    {
       
        if (border.gameObject.CompareTag("border"))
        {
            border_tag = true;


        }
     /*   if (border.gameObject.CompareTag("reset_border"))
        {
            reset_border_tag = true;


        }*/

        /* if (border.gameObject.CompareTag("borderleft"))
         {
             border_left_tag = true;


         }*/

    }

    void follow()
    {



     
       


            if (Vector2.Distance(transform.position, main.position) <= followDis && (main.position.x - transform.position.x > 0))//跟随距离
            {

                Vector2 transformValue = new Vector2(10, 0);


                playerRigidbody.velocity = transformValue;

            }



            else if (Vector2.Distance(transform.position, main.position) <= followDis && (main.position.x - transform.position.x < 0))//跟随距离
            {

                Vector2 transformValue = new Vector2(-10, 0);

                playerRigidbody.velocity = transformValue;

            }


        

    }


    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Transform target = GameObject.FindGameObjectWithTag("main").transform;

    }
    
   
    

    void move()
    {

        /*this.gameObject.transform.position += new Vector3(speed, 0f, 0f);*/
        Vector2 transformValue = new Vector2(speed, 0);

        playerRigidbody.velocity = transformValue;
        if (border_tag==true)
        {
          
            speed = speed * -1;

            border_tag = false;
        }        


        
        
    }
  
    void Update()
    {
       
    

        enemyposition = this.gameObject.transform.position.x;
    

        if ((Vector2.Distance(transform.position, main.position) <= followDis && (main.position.x - transform.position.x > 0)))
        {
            follow();
           
        }
        else
        {
            move();


        }
       
    }
   
   }

