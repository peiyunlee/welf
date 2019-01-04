using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class littleEnemy2_health : MonoBehaviour {

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
    public bool isDead;
    bool isSinking;
    bool bullet_tag = false;

    // Use this for initialization

    //傷害
    void resetanim()
    {
        Debug.Log("In reset");
        anim.SetBool("littleEnemy2_behurt", false);
        CancelInvoke("resetanim");
    }


    public void TakeDamage(int amount = 1)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
        anim.SetBool("littleEnemy2_behurt", true);
        Invoke("resetanim", 0.1f);
        Debug.Log(currentHealth);



    }

    //死亡
    void Death()
    {
        Debug.Log("Dead");
        isDead = true;
        /*capsuleCollider.isTrigger = true;*/
        /*anim.SetTrigger("Dead");*/
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




    void Start()
    {

        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
}
