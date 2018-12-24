using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleEnemy_Health : MonoBehaviour {
    //遊戲開始時小怪的初始血量
    public int startingHealth = 5;
    //遊戲過程中記錄小怪血量
    public int currentHealth;
    //怪物死亡數目
    public int enemy_dead = 0;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    public bool isDead=false;
    bool isSinking;
    bool bullet_tag = false;
    // Use this for initialization

    //傷害
    void resetanim()
    {
        anim.SetBool("middleEnemy_hurt", false);
        CancelInvoke("resetanim");
    }
public void TakeDamage(int amount = 1)
    {
        
        anim.SetBool("middleEnemy_hurt", true);
        Invoke("resetanim", 0.5f);
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }

    }

    //死亡
    void Death()
    {
        Debug.Log("Dead");
        isDead = true;
        anim.SetTrigger("Dead");
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
        /*anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        */
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame

}
