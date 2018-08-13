using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    //攻擊模式
    enum AttackMode
    {
        Normal,
        Skill
    };

    AttackMode attackMode;

    public float timeBetweenSkill = 2f;
    public int attackDamage;
    float timer;

    //條件設定
    bool canUseSkill;
    bool isAttack;
    bool isSkill;

    //按鍵設定    
    bool keyClear;

    GameObject player;
    PlayerHealth playerHealth;
    Animator playerAnim;

    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag("Cube");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= timeBetweenSkill)
        {
            canUseSkill = true;
        }
    }
    void FixedUpdate()
    {
        GetKey();

        Attack();
    }

    void GetKey()
    {
        if (Input.GetButtonDown("Attack"))
        {
            attackMode = AttackMode.Normal;

            isAttack = true;

            Debug.Log("Normal");
        }
        if (Input.GetButtonDown("Skill") && canUseSkill)
        {
            attackMode = AttackMode.Skill;

            isSkill = true;

            Debug.Log("Skill");
        }
        //keyClear = Input.GetButtonDown("Clear");
    }

    void Attack()
    {
        if (attackMode == AttackMode.Normal)
        {
            attackDamage = 1;

            
        }
        if (attackMode == AttackMode.Skill)
        {
            attackDamage = 2;

            canUseSkill = false;

            timer = 0;

            
        }

        playerHealth.TakeDamage(attackDamage);
       
    }
    void Ainimating()
    {
        //playerAnim.SetBool("IsRun", isWalking);


        /*playerAnim.SetBool("IsJump", isRoll);//翻滾(暫時用Jump代替)*/

    }
}
