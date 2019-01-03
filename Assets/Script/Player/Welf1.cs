using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welf1 : SkillSet {
    public float setTime = 0;
    private float clearTime = 1;
    private float timer=0;

    private bool canUseSkill = true;
    private bool istouch = false;

    //主角相關
    GameObject player;
    Animator playAnim;

    //水精靈相關
    Animator welfAnim;

    //技能相關
    [SerializeField]
    GameObject water;
    private HealthTest healthTest;
    public GameObject welfuiobject;
    private SkillCoolDown skillcooldown;
    private AttackDetect attackDetect;
    // Use this for initialization
    void Start () {
        healthTest = null;
        player = GameObject.FindWithTag("Player");
        playAnim = player.GetComponent<Animator>();
        attackDetect = player.GetComponent<AttackDetect>();

        welfAnim = GetComponent<Animator>();

        //welfuiobject = GameObject.FindWithTag("WelfUI");
        //skillcooldown = welfuiobject.GetComponent<SkillCoolDown>();
    }
	
	// Update is called once per frame
	void Update () {
        GetKey();
        
        if (keySkill&&!isSkill)//&& !skillcooldown.iscoolskill[WelfSelect.iWelfCount-1])
        {
            isSkill = true;
            //water.SetActive(true);
            if (attackDetect.isTouch)
            {
                if (attackDetect.health[0])
                {
                    healthTest.TakeDamage(2);
                }
                if (attackDetect.health[1])
                {
                    attackDetect.enemyHealth.TakeDamage(2);
                }
                if (attackDetect.health[2])
                {
                    attackDetect.middleHealth.TakeDamage(2);
                }
                if (attackDetect.health[3])
                {
                    attackDetect.littleEnemy.TakeDamage(2);
                }
            }
            //skillcooldown.UseSkill(WelfSelect.iWelfCount);
            PlayerMovement.canMove = false;
        }

        if (isSkill)
        {
            timer += Time.deltaTime;        
        }
        if (timer >= clearTime)
        {
            isSkill = false;

            //water.SetActive(false);

            timer = 0;

            PlayerMovement.canMove = true;
        }
        Animation();
        //isSkill = false;
        //Debug.Log(canUseSkill);
        //Debug.Log("touch");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //if (other.CompareTag("EnemyTest"))
        //{
        //    istouch = true;

        //    healthTest = other.GetComponent<HealthTest>();
        //}
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.CompareTag("EnemyTest"))
        //{
        //    istouch = false;

        //    healthTest = null;
        //}
    }

    void GetKey()
    {
        keySkill = Input.GetButtonDown("Skill");
    }

    void Animation()
    {
        playAnim.SetBool("isSkill", isSkill);

        welfAnim.SetBool("isSkill", isSkill);
    }
}
