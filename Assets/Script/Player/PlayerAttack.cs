using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : AttackDetect {
    public enum Attack
    {
        idle,
        normal=1,
        skill
    }

    int hurt;
    int attackCount = 0;
    bool keyAttack;
    bool keySkill;
    bool isSkill;

    //動畫名稱
    private const string idleState = "Idle";
    private const string runState = "Run1";
    private const string attack1State = "Attack1";
    private const string attack2State = "Attack2";

    PlayerMovement playerMovement; 
    Animator playerAnim;
    AnimatorStateInfo animSta;
    // Use this for initialization
    void Start () {
        playerAnim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

        hurt = 0;
    }
	
	// Update is called once per frame
	void Update () {
        GetKey();

        Animating();

        if (!PlayerMovement.isMenu)
        {
            SetAttack();
        }
    }

    int Hurt(Attack attack)
    {
        switch (attack)
        {
            case Attack.idle:
                hurt = 0;
                break;
            case Attack.normal:
                hurt = 1;
                break;
            case Attack.skill:
                hurt = 2;
                break;
        }
        return hurt;
    }
 
    void SetAttack()
    {
        //讀取player動畫狀態
        animSta = playerAnim.GetCurrentAnimatorStateInfo(0);
        //返回idle狀態
        if (!animSta.IsName(idleState)&&animSta.normalizedTime>1.0f)
        {
            if (isTouch)
            {
               healthTest.TakeDamage(Hurt(Attack.idle));
            }
            attackCount = 0;
            playerAnim.SetInteger("Attack", attackCount);
        }
        //攻擊
        if (keyAttack && playerMovement.isGround)
        {
            //一段攻擊
            if ((animSta.IsName(idleState)|| animSta.IsName(runState)) && attackCount == 0)
            {
                if (isTouch)
                {
                    healthTest.TakeDamage(Hurt(Attack.normal));
                }
                attackCount = 1;
                playerAnim.SetInteger("Attack", attackCount);
            }
            //二段攻擊
            if (animSta.IsName(attack1State) && attackCount == 1 && animSta.normalizedTime > 0.5f)
            {
                if (isTouch)
                {
                    healthTest.TakeDamage(Hurt(Attack.normal));
                }
                attackCount = 2;
                playerAnim.SetInteger("Attack", attackCount);
            } 
        }

        if (keySkill)
        {
            playerAnim.SetTrigger("isSkill");
        }
    }

    void GetKey()
    {
        keyAttack = Input.GetButtonDown("Attack");
        keySkill = Input.GetButtonDown("Skill");
    }

    void Animating()
    {
       
    }
}
