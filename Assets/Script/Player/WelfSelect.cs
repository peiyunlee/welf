using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelfSelect : MonoBehaviour
{
    public GameObject[] mainWelf;//所有水精靈

    private GameObject mpMainWelf;//主要角色
    private GameObject spMainWelf;
    public GameObject welfuiobject;
    private WELFUI welfui;

    [SerializeField]
    private int iWelfCount = 1;//計算第幾隻水精靈
    //[SerializeField]
    //private int[] testWelf = new int[2];//GameManager的傳值測試

    private int[] chooseWelf = new int[2];//存放玩家所選的水精靈

    private bool canChange = true;
    private bool isChange=false;
    private float timer = 0;
    public float changeTime = 2.0f;

    Transform mainTrans;
    [SerializeField]
    SkillSet skillSet;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            chooseWelf[i] = GameManager.chooseelf[i];
            //chooseWelf[i] = testWelf[i];
        }//設定玩家選哪幾隻elf

        mainTrans = GameObject.FindWithTag("Player").transform;

        spMainWelf = null;
        isChange = true;

        welfui=welfuiobject.GetComponent<WELFUI>();
        Debug.Log("aaaa" + GameManager.chooseelf[0] + "aaaaa" + GameManager.chooseelf[1]);
        Debug.Log("bbbb" + chooseWelf[0] + "bbbb" + chooseWelf[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
            ChangeCharacter();
 

        isChange = false;
        //Debug.Log(canChange);

    }

    void ChangeCharacter()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            iWelfCount++;
            if (iWelfCount >= 3)
            {
                iWelfCount = 1;
            }
            welfui.ExecuteAnime(iWelfCount);
            mpMainWelf = null;
            isChange = true;
        }

        switch (iWelfCount)
        {
            case 1:
                {
                    if (mpMainWelf == null)
                    {
                        mpMainWelf = mainWelf[chooseWelf[0]-1];
                        //設定主要Welf為第一隻
                    }
                }
                break;
            case 2:
                {
                    if (mpMainWelf == null)
                    {
                        mpMainWelf = mainWelf[chooseWelf[1]-1];
                        //設定主要Welf為第二隻
                    }
                }
                break;
        }
        //for (int i = 0; i < mainWelf.Length; i++)
        //{
        //    mainWelf[i].SetActive(false);
        //}
        //mpMainWelf.SetActive(true);
        //設定主要Welf為active 
        if (isChange)
        {
            for (int i = 0; i < mainWelf.Length; i++)
            {
                DestroyImmediate(GameObject.FindGameObjectWithTag("Welf"), true);
            }
            Instantiate(mpMainWelf, mainTrans);
        }
    }
}
