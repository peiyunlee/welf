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
    [SerializeField]
    private bool[] whitchelfpause;      //換水精靈暫停冷卻
    [SerializeField]
    private bool[] iscoolskill;      //換水精靈暫停冷卻

    //public bool [] testbool;         //test
    //public bool[] testcanuseskill;      //test 現在有無冷卻可否使用

    public void UseSkill(int whitchelf)
    {
        if (currentCoolDown[whitchelf-1] >= coolDown)
        {
            //testcanuseskill[whitchelf - 1] = false;   //test

            iscoolskill[whitchelf - 1] = true;  //開始冷卻
            currentCoolDown[whitchelf - 1] = 0;   // 重置冷却时间
        }
    }
    public void PauseSkillCoolDown(int whitchelf)
    {
        if (currentCoolDown[whitchelf - 1] < coolDown)
        {
            whitchelfpause[whitchelf - 1] = true;
        }
    }
    public void StartSkillCoolDown(int whitchelf)
    {
        if (currentCoolDown[whitchelf - 1] < coolDown)
        {
            whitchelfpause[whitchelf - 1] = false;
        }
    }
    void Start()
    {
        currentCoolDown = new float[2];
        whitchelfpause = new bool[2];
        iscoolskill = new bool[2];
        //testcanuseskill = new bool[2];   //test
        for (int i = 0; i < 2; i++)
        {
            currentCoolDown[i] = 10;
            iscoolskill[i] = false;
            whitchelfpause[i] = false;

            //testcanuseskill[i] = true;   //test
        }
    }
    void Update()
    {
        ///////////////////////////////test///////////////////////////////////////////
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
        //////////////////////////////////////////////////////////////////////////////

        for (int i = 0; i < 2; i++)
        {
            switch (iscoolskill[i])
            {
                case false:
                    if (currentCoolDown[i] < coolDown)
                    {
                        if(!whitchelfpause[i])// 更新冷却
                            currentCoolDown[i] += Time.deltaTime;
                    }
                    if (currentCoolDown[i] > coolDown)
                    {
                        //testcanuseskill[i] = true;  //test
                        iscoolskill[i] = true;  //結束冷卻
                    }
                    // 显示冷却动画
                    icon[i].fillAmount = (coolDown - currentCoolDown[i]) / coolDown;
                    break;
                case true:
                    break;

            }
            
        }
        
    }
}
