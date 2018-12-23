using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleEnemy_Health : MonoBehaviour {
    //遊戲開始時小怪的初始血量
    public int startingHealth = 100;
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
    public void TakeDamage(int amount = 10)
    {
        Debug.Log("damaged");
        if (isDead)
            return;

      
        Debug.Log(currentHealth);
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
        capsuleCollider.isTrigger = true;
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

        currentHealth = startingHealth;
    }

    // Update is called once per frame

}
