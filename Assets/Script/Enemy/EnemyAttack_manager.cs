using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack_manager : MonoBehaviour {
  
    public Transform main;//要跟随英雄
    public float attackDis = 10f;//達到此距離開始攻擊
    public static bool bighit_state_right = false;
    public static bool bighit_state_left = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //bighit開始攻擊
       
        if (Vector2.Distance(transform.position, main.position) <= attackDis && (main.position.x - transform.position.x > 0))
        {
            bighit_state_right = true;
            


        }
        if (Vector2.Distance(transform.position, main.position) <= attackDis && (main.position.x - transform.position.x < 0))//跟随距离
        {

            bighit_state_left = true;


        }
    }
}
