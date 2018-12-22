using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolDown : MonoBehaviour {

    // 技能的图标
    public Image [] icon;
    // 技能的冷却时间
    public float coolDown;
    // 保存当前技能的冷却时间
    [SerializeField]
    private float [] currentCoolDown;
    public bool [] testbool;         //test
    public bool[] testcanuseskill;
    public void UseSkill(int whitchelf)
    {
        if (currentCoolDown[whitchelf-1] >= coolDown)
        {
            testcanuseskill[whitchelf - 1] = false;
            // 重置冷却时间
            currentCoolDown[whitchelf - 1] = 0;
        }
    }
    void Start()
    {
        currentCoolDown = new float[2];
        testcanuseskill = new bool[2];   //test
        for (int i = 0; i < 2; i++)
        {
            currentCoolDown[i] = 10;
            testcanuseskill[i] = true;
        }
        UseSkill(1);
    }
    void Update()
    {
        /////////////////////////////////
        //if (testbool[0])
        //{
        //    UseSkill(1);
        //    testbool[0] = false;
        //}
        //else if (testbool[1])
        //{
        //    UseSkill(2);
        //    testbool[1] = false;
        //}
        //////////////////////////////////////
        for (int i = 0; i < 2; i++)
        {
            switch (testcanuseskill[i])
            {
                case false:
                    if (currentCoolDown[i] < coolDown)
                    {
                        // 更新冷却
                        currentCoolDown[i] += Time.deltaTime;
                        // 显示冷却动画
                        icon[i].fillAmount = (coolDown - currentCoolDown[i]) / coolDown;
                    }
                    if (currentCoolDown[i] > coolDown)
                    {
                        testcanuseskill[i] = true;
                    }
                    break;
                case true:
                    break;

            }
            
        }
        
    }
}
