using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public enum Attack
    {
        idle,
        normal,
        skill
    }

    int hurt = 0;
    int attackCount = 0;
    bool keyAttack;
    bool isAttack = false;

    //動畫名稱
    private const string idleState = "Idle";
    private const string runState = "Run1";
    private const string attack1State = "Attack1";
    private const string attack2State = "Attack2";

    GameObject attackRange;

    SetAttack setAttack;
    PlayerMovement playerMovement;
    Animator playerAnim;
    AnimatorStateInfo animSta;
    // Use this for initialization
    void Start() {
        playerAnim = GetComponent<Animator>();
        setAttack = GetComponent<SetAttack>();
        Debug.Log("pa");
        attackRange = GameObject.FindGameObjectWithTag("playerAttack");

        // attackRange.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        GetKey();

        AttackSet();
    }

    void AttackSet()
    {
        animSta = playerAnim.GetCurrentAnimatorStateInfo(0);
        if (!animSta.IsName(idleState) && animSta.normalizedTime > 1.0f)
        {
            attackCount = 0;
            playerAnim.SetInteger("Attack", attackCount);
            //attackRange.SetActive(false);
        }
        if (keyAttack)
        {
            if ((animSta.IsName(idleState)|| animSta.IsName(runState)) && attackCount == 0)
            {
                // attackRange.SetActive(true);
               
                attackCount = 1;
                playerAnim.SetInteger("Attack", attackCount);
            }
            if (animSta.IsName(attack1State) && attackCount == 1 && animSta.normalizedTime > 0.5f)
            {
                //attackRange.SetActive(true);
                attackCount = 2;
                playerAnim.SetInteger("Attack", attackCount);
            }
            //if (attackCount == 2)
            //{
            //    attackCount = 0;
            //}
        }
        // isAttack = false;
    }



        void GetKey()
        {
            keyAttack = Input.GetButtonDown("Attack");
        }
    }
