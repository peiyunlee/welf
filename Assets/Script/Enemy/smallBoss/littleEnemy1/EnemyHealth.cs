using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    //遊戲開始時小怪的初始血量
    public int startingHealth = 12;
    //遊戲過程中記錄小怪血量
    public int currentHealth;
    //怪物死亡數目
    public int enemy_dead = 0;
   
    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    Enemymovement enemymovement;
    public bool isDead;
    bool isSinking;
    bool bullet_tag=false;
    float timer = 0f;
    
    // Use this for initialization

    //傷害
    void resetanim()
    {
       
        anim.SetBool("littleEnemy_behurt", false);
        CancelInvoke ("resetanim");
    }


    public void TakeDamage(int amount = 1)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
        
        anim.SetBool("littleEnemy_behurt", true);
        Invoke("resetanim", 0.1f);
       

    }

    //死亡
    void Death()
    {
       
        isDead = true;
        enemy_dead++;
        
    }




    //偵測是否觸碰到子彈
    void OnTriggerEnter2D(Collider2D border)
    {

        if (border.gameObject.CompareTag("bullet"))
        {
          
            TakeDamage();

        }
    }




    void Start () {

        anim = GetComponent<Animator>();
        enemymovement =GetComponent<Enemymovement>();
        currentHealth = startingHealth;
    }

  

}
