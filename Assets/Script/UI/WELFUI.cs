using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WELFUI : MonoBehaviour {
    [SerializeField]
    GameObject [] gameobject;
    [SerializeField]
    Image [] myImage;
    [SerializeField]
    Animator [] anim;
    [SerializeField]
    private int [] mychooseelf;
    [SerializeField]
    public int whitchelftest;  //test player use whitchelf
    [SerializeField]
    public bool ischangetest;  //test
    private SkillCoolDown skillcooldown;
    // Use this for initialization
    void Start () {
        anim[0]=gameobject[0].GetComponent<Animator>();
        anim[1] = gameobject[1].GetComponent<Animator>();
        //mychooseelf[0] = GameManager.chooseelf[0];
        //mychooseelf[1] = GameManager.chooseelf[1];
        mychooseelf[0] = 1;
        mychooseelf[1] = 3;
        anim[0].SetTrigger(mychooseelf[0] + "tobig");
        anim[1].SetTrigger(mychooseelf[1] + "tosmall");

        ////////////////////////////////////////////////TEST////////////////////////////////
        //mychooseelf[0] = 3;        
        //mychooseelf[1] = 2;
        ischangetest = false;
        whitchelftest = 1;
        ///////////////////////////////////////////////////////////////////////////////////


        //myImage[0].sprite = Resources.Load("Images/UI/遊戲頭像/" + mychooseelf[0] + "_C", typeof(Sprite)) as Sprite;
        //myImage[1].sprite = Resources.Load("Images/UI/遊戲頭像/" + mychooseelf[1] + "_H", typeof(Sprite)) as Sprite;
        //myImage[2].sprite = Resources.Load("Images/UI/遊戲頭像/" + mychooseelf[0] + "_CS", typeof(Sprite)) as Sprite;
        //myImage[3].sprite = Resources.Load("Images/UI/遊戲頭像/ALL_N", typeof(Sprite)) as Sprite;

        skillcooldown = gameObject.GetComponent<SkillCoolDown>();//test
    }
	
	void Update () {
        ////////////////////////////////////////////////TEST////////////////////////////////
        if (ischangetest)
        {
            skillcooldown.PauseSkillCoolDown(whitchelftest);   //先暫停切換前該水精靈技能
            whitchelftest = (whitchelftest % 2)+1;   //換哪隻水精靈
            ExecuteAnime(whitchelftest);     //呼叫切換頭向動畫
            skillcooldown.StartSkillCoolDown(whitchelftest);     //開始計時切換後該水精靈技能
            ischangetest = false;
        }
        ///////////////////////////////////////////////////////////////////////////////////

    }
    public void ExecuteAnime(int whitchelf)
    {
        if (whitchelf == 1)
        {
            anim[0].SetTrigger(mychooseelf[0] + "tobig");
            anim[1].SetTrigger(mychooseelf[1] + "tosmall");
        }
        else if (whitchelf == 2)
        {
            anim[0].SetTrigger(mychooseelf[0] + "tosmall");
            anim[1].SetTrigger(mychooseelf[1] + "tobig");
        }
    }
}
