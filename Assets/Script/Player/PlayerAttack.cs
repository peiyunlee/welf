using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    enum Attack
    {
        normal,
        skill
    }
    Attack playerAttack;

    int attackCount = 0;
    bool keyAttack;
    bool isAttack = false;

    //動畫名稱
    private const string idleState = "Idle";
    private const string attack1State = "Attack1";
    private const string attack2State = "Attack2";
    PlayerMovement playerMovement;
    Animator playerAnim;
    AnimatorStateInfo animSta;
    // Use this for initialization
    void Start () {
        playerAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        GetKey();

        Animating();

        SetAttack();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void SetAttack()
    {
        animSta = playerAnim.GetCurrentAnimatorStateInfo(0);
        if (!animSta.IsName(idleState)&&animSta.normalizedTime>1.0f)
        {
            attackCount = 0;
            playerAnim.SetInteger("Attack", attackCount);
        }
        if (keyAttack)
        {
            if (animSta.IsName(idleState) && attackCount == 0)
            {
                attackCount = 1;
                playerAnim.SetInteger("Attack", attackCount);
            }
            if (animSta.IsName(attack1State) && attackCount == 1 && animSta.normalizedTime > 0.5f)
            {
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

    void Animating()
    {

    }
}
