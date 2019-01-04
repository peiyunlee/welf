using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welf1 : SkillSet {
    //public static bool isSkill = false;
    public float setTime = 0.00001f;
    private float clearTime = 1;
    private float timer = 0;

    private bool canUseSkill = true;
    private bool istouch = false;
    public bool isHurt = false;

    //主角相關
    GameObject player;
    Animator playAnim;

    //水精靈相關
    Animator welfAnim;

    //技能相關
    [SerializeField]
    GameObject water;
    public HealthTest healthTest;
    public EnemyHealth enemyHealth;
    public middleEnemy_Health middleHealth;
    public littleEnemy2_health littleEnemy;
    public GameObject welfuiobject;
    private SkillCoolDown skillcooldown;
    private AttackDetect attackDetect;
    public bool[] health;
    // Use this for initialization
    void Start() {
        health = new bool[4];
        istouch = false;
        //healthTest = null;
        player = GameObject.FindWithTag("Player");
        playAnim = player.GetComponent<Animator>();
        attackDetect = player.GetComponent<AttackDetect>();

        welfAnim = GetComponent<Animator>();

        welfuiobject = GameObject.FindWithTag("WelfUI");
        skillcooldown = welfuiobject.GetComponent<SkillCoolDown>();

        for (int i = 0; i < 4; i++)
        {
            health[i] = false;
        }
    }

    // Update is called once per frame
    void Update() {
        GetKey();

        if (keySkill && !isSkill && !PlayerMovement.isJumping && !skillcooldown.iscoolskill[WelfSelect.iWelfCount - 1])
        {
            isSkill = true;
            //water.SetActive(true);

            skillcooldown.UseSkill(WelfSelect.iWelfCount);
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

    public void Hurt()
    {
        if (istouch)
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
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("EnemyTest"))
        {
            istouch = true;

            healthTest = other.GetComponent<HealthTest>();

            health[0] = true;
        }

        if (other.CompareTag("main"))
        {
            istouch = true;

            enemyHealth = other.GetComponent<EnemyHealth>();

            health[1] = true;
        }

        if (other.CompareTag("middlemain"))
        {
            istouch = true;

            middleHealth = other.GetComponent<middleEnemy_Health>();

            health[2] = true;
        }

        if (other.CompareTag("main2"))
        {
            istouch = true;

            littleEnemy = other.GetComponent<littleEnemy2_health>();

            health[3] = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("EnemyTest"))
        {
            istouch = false;

            healthTest = null;

            health[0] = false;
        }
        if (other.CompareTag("main"))
        {
            istouch = false;

            enemyHealth = null;

            health[1] = false;
        }

        if (other.CompareTag("middlemain"))
        {
            istouch = false;

            middleHealth = null;

            health[2] = false;
        }
        if (other.CompareTag("main2"))
        {
            istouch = false;

            littleEnemy = null;

            health[3] = false;
        }
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
