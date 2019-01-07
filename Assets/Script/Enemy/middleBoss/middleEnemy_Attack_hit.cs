using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class middleEnemy_Attack_hit : MonoBehaviour {
    Animator anim;
    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄
    public bool hit_flag=false;
    private middleEnemy_movement movement;
    public bool state=false;
    float timer=0;
    public bool normalhit_state =false;
    PlayerHealth playerHealth;

    public void middleBoss_hit()
    {
        playerHealth.TakeDamage(1);
        normalhit_state = true;
      
        timer += Time.deltaTime;
        Debug.Log(timer);
        
        if (timer>4)
        {
            Debug.Log("normalhit_state = false");
           
            normalhit_state = false;
            timer = 0;
            Debug.Log(timer);
           
          
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth = collision.GetComponent<PlayerHealth>();
            

        }
    }

    // Use this for initialization
    void Start () {
        
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        movement = GetComponent<middleEnemy_movement>(); //與外部判斷是否fire做連結
    }
	
	
}
