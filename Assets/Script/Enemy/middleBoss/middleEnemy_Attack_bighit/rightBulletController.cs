using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightBulletController : MonoBehaviour {
    public float rate = 3; //發子彈的速率
    public GameObject bullet;//取得子彈的gameobject
    public bool state = false;
    private middleEnemy_movement movement;
    EnemyAttack_manager manager;
    float timer = 0f;
   
    // Use this for initialization
    void Start()
    {
        movement = GetComponent<middleEnemy_movement>(); //與外部判斷是否fire做連結
        manager = GetComponent<EnemyAttack_manager>();
    }


   /* void Update()
    {
        timer += Time.deltaTime;
        if (timer>1.5f)
        {
            state = false;
            timer = 0;

        }
       if (state == false && manager.bighit_state_right == true) {  //判斷是否開火，state則確保僅開火一次
            
            fire();
           state = true;
        }
     
    }*/


    public void fire()
    {
       

            GameObject.Instantiate(bullet, transform.position, Quaternion.identity);//複製子彈
            
        
    }
}
