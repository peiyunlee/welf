using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftBulletController : MonoBehaviour {
   
    public float rate = 3; //發子彈的速率
    public GameObject bullet;//取得子彈的gameobject
   public bool state = false;
    public middleEnemy_movement movement;
    
    // Use this for initialization
    void Start () {
        movement = GetComponent<middleEnemy_movement>(); //與外部判斷是否fire做連結
        
       

    }
    void Update()
    {

        

        if (state == false && EnemyAttack_manager.bighit_state_left == true)//判斷是否開火，state則確保僅開火一次
         {  

             fire();
             state = true;



         }
       

    }

    public void fire()
    {
        GameObject.Instantiate(bullet,transform.position,Quaternion.identity);//複製子彈*

      
    }
    

    
}
