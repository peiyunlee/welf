using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class littleEnemy_Attack_shock : MonoBehaviour {
   // private Enemymovement enemymovement;
    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄
    private Enemymovement Enemymovement;
    public bool state = false;
    float speed = 100f;//衝擊速度
    float shockRange = 10f;
    public float timer = 0;
    public bool State_right = false;
    public bool State_left = false;
    void refresh()
    {

        transform.Translate(new Vector2(initialposition, 0) * 1f);



    }


    public void normalAttack_hit_right()
    {
       // State_right = true;
        timer += Time.deltaTime;
       
        if (Enemymovement.timer >= 0.5f && Enemymovement.timer <= 2.5f)//暫停時間
        {
            Vector2 transformValue = new Vector2(0, 0);
           // playerRigidbody.velocity = transformValue;

        }
        else if (Enemymovement.timer >= 2.5f && Enemymovement.timer <= 3f)//返回時間
        {
            /* transform.Translate(Vector3.left * speed * Time.deltaTime);*/
            State_right = false;
          

        }
       /* else if (timer >= 2f)
        {

            State_right = false;

        }*/
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);


        }



    }


    public void normalAttack_hit_left()
    {
        timer += Time.deltaTime;
       // State_left = true;
        if (Enemymovement.timer >= 0.5f && Enemymovement.timer <= 2f)//暫停時間
        {
            Vector2 transformValue = new Vector2(0, 0);
            // playerRigidbody.velocity = transformValue;

        }
        else if (Enemymovement.timer >= 2.5f && Enemymovement.timer <= 3f)//返回時間
        {
           /* transform.Translate(Vector3.right * speed * Time.deltaTime);*/
            State_left = false;
           
        }
       /* else if (timer >= 2f)
        {

            State_left = false;

        }*/
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);


        }



    }


    private float initialposition;
    private void Start()
    {
        initialposition = transform.position.x;
        playerRigidbody = GetComponent<Rigidbody2D>();
        Transform target = GameObject.FindGameObjectWithTag("main").transform;
        Enemymovement = GetComponent<Enemymovement>(); //與外部判斷是否fire做連結
      //  enemymovement = GetComponent<Enemymovement>();
    }


   


}
