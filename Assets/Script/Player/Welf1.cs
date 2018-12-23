using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welf1 : SkillSet {
    public float setTime = 1;
    private float clearTime = 2;

    private bool canUseSkill = true;
    private bool isTouch = false;

    //主角相關
    GameObject player;
    Animator playAnim;

    //水精靈相關
    Animator welfAnim;

    //技能相關
    [SerializeField]
    GameObject water;
    HealthTest healthTest;
    // Use this for initialization
    void Start () {
        healthTest = null;
        player = GameObject.FindWithTag("Player");
        playAnim = player.GetComponent<Animator>();

        welfAnim = GetComponent<Animator>();    
    }
	
	// Update is called once per frame
	void Update () {
        GetKey();
        
        if (keySkill&&!isSkill)
        {
            isSkill = true;
            if (isTouch)
            {
                healthTest.TakeDamage(hurt);
            }

        }

        if (isSkill)
        {
            timer += Time.deltaTime;
            
        }

        if (timer >= setTime)
        {
            water.SetActive(true);
        }
        if (timer >= clearTime)
        {
            isSkill = false;

            water.SetActive(false);

            timer = 0;
        }
        Animation();
        //Debug.Log(canUseSkill);
        //Debug.Log("touch");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("EnemyTest"))
        {
            isTouch = true;

            healthTest = other.GetComponent<HealthTest>();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("EnemyTest"))
        {
            isTouch = false;

            healthTest = null;
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
