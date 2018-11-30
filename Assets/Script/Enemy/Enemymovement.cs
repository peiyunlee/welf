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
    bool border_right_tag=false;
    bool enemy_long_tag = false;
    bool border_left_tag = false;

    public float followDis = 100f;//达到这个距离开始跟随
    public float speed = 0.5f;
    private float enemyposition;
    public int enemyinitiallocat;
    void OnTriggerEnter2D(Collider2D border)
    {
        Debug.Log("sdfsdf");
        if (border.gameObject.CompareTag("border"))
        {
            border_right_tag = true;


        }
        if (border.gameObject.CompareTag("enemylongborder"))
        {
            enemy_long_tag = true;


        }
        if (border.gameObject.CompareTag("borderleft"))
        {
            border_left_tag = true;


        }

    }
    
    void follow()
    {

        /* playerRigidbody.velocity= new Vector2(3, 0);*/

        if (Vector2.Distance(transform.position, main.position) <= followDis && (main.position.x - transform.position.x > 0))//跟随距离
        {

            Vector2 transformValue = new Vector2(10, 0);


            playerRigidbody.velocity = transformValue;

        }



        if (Vector2.Distance(transform.position, main.position) <= followDis && (main.position.x - transform.position.x < 0))//跟随距离
        {

            Vector2 transformValue = new Vector2(-10, 0);

            playerRigidbody.velocity = transformValue;

        }
        if (enemy_long_tag == true)
        {
            Debug.Log("20");
            while (border_left_tag!=true)
            {
                Vector2 transformValue = new Vector2(-10, 0);

            }
            enemy_long_tag = false;
            border_left_tag = false;


        }

    }

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Transform target = GameObject.FindGameObjectWithTag("main").transform;

    }
    
   
    public int enemylong=20;

    void move()
    {
        
        this.gameObject.transform.position += new Vector3(speed, 0f, 0f);
        if (border_right_tag==true)
        {
            /*Debug.Log("1");*/
            speed = speed * -1;

            border_right_tag = false;
        }        


        
        
    }
   /* void reset()
    {




    }*/
    void Update()
    {
        /*Debug.Log(speed);
        Debug.Log(enemyposition);*/

        enemyposition = this.gameObject.transform.position.x;
        /*if (enemy_long_tag == true)
        {
            reset();
        }*/

        if ((Vector2.Distance(transform.position, main.position) <= followDis && (main.position.x - transform.position.x > 0))&&(enemyposition<8))
        {
            follow();
           
        }
        else
        {
            move();


        }
       
    }
   
   }

