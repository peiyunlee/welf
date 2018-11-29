using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Enemymovement : MonoBehaviour {

    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄
    private CharacterController con;//怪物的角色控制器
    

    public float followDis = 100f;//达到这个距离开始跟随
    /*public float attackDis = 2f;//达到这个距离开始攻击

    public float thinkTime = 3f;//思考的时间
    public float currentThinkTime = 0f;//记录思考的时间

    public float walkTime = 5f;//走的时间
    public float currentWalkTime = 0;//记录走的时间

    private bool isAttact = false;//是否攻击
    */
    private float speed = 0.1f;
    private float enemyposition;
    public int enemyinitiallocat;
    void follow() {

       /* playerRigidbody.velocity= new Vector2(3, 0);*/

        if (Vector2.Distance(transform.position, main.position) <= followDis&&(main.position.x-transform.position.x>0))//跟随距离
        {
           
            Vector2 transformValue = new Vector2(10, 0);
            
            
            playerRigidbody.velocity = transformValue;

        }



        if (Vector2.Distance(transform.position, main.position) <= followDis && (main.position.x - transform.position.x < 0))//跟随距离
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
    
    int time = 0;
    void move()
    {
        
          this.gameObject.transform.position += new Vector3(speed, 0f, 0f);
        time++;
        if (time==100)
        {

            speed = speed * -1;
            time = 0;

        }


        
        
    }

    void Update()
    {
        /*Debug.Log(speed);
        Debug.Log(enemyposition);*/

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
