using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleEnemy_Attack_shock : MonoBehaviour {
    Animator anim;
    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄
    private EnemyAttack_manager EnemyAttack_manager;
    public bool state = false;
    float speed =100f;//衝擊速度
    float shockRange =10f;
    float timer = 0;
    bool overState = false;
    void refresh()
    {
       
            transform.Translate(new Vector2(initialposition, 0) * 1f);

        

    }


    private void normalAttack_hit()
    {
       
        timer += Time.deltaTime;

        if (timer>=0.5f&&timer<=1.5f)//暫停時間
        {
            Vector2 transformValue = new Vector2(0, 0);
            playerRigidbody.velocity = transformValue;

        }
        else if(timer >= 1.5f && timer <= 2f)//返回時間
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        }
        else if (timer >= 2f)
        {

            overState = true;

        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);


        }
       


    }

    private float initialposition;
    private void Start()
    {
        anim = GetComponent<Animator>();
        initialposition = transform.position.x;
        playerRigidbody = GetComponent<Rigidbody2D>();
        Transform target = GameObject.FindGameObjectWithTag("main").transform;
        EnemyAttack_manager = GetComponent<EnemyAttack_manager>(); //與外部判斷是否fire做連結
    }


    private void Update()
    {

       
        if (overState==false&& EnemyAttack_manager.shockhit_state==true)
        {
            anim.SetBool("middle_enemy_shock_start ", true);
            normalAttack_hit();
          
            state = true;
        }

        Debug.Log(overState);
        if (overState == true)
        {

            anim.SetBool("middle_enemy_shock_start ", false);

    
        }
    }

}
