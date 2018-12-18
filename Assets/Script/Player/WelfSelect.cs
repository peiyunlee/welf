using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelfSelect : MonoBehaviour {
    public GameObject[] mainWelf;//所有水精靈

    private GameObject mpMainWelf;//主要角色

    [SerializeField]
    private int iWelfCount = 0;//計算第幾隻水精靈
    [SerializeField]
    private int[] testWelf = new int[2];//GameManager的傳值測試

    private int[] chooseWelf=new int[2];//存放玩家所選的水精靈

    [SerializeField]
    GameManager gameManager;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 2; i++)
        {
            //chooseWelf[i] = GameManager.chooseelf[i];
            chooseWelf[i] = testWelf[i];
        }//設定玩家選哪幾隻elf
	}
	
	// Update is called once per frame
	void Update () {
        ChangeCharacter();

        Debug.Log(mpMainWelf);

    }

    void ChangeCharacter()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            iWelfCount++;
            if (iWelfCount >= 2)
            {
                iWelfCount = 0;
            }
            mpMainWelf = null;
        }

        switch (iWelfCount)
        {
            case 0 :
                {
                    if (mpMainWelf == null) {
                        mpMainWelf = mainWelf[chooseWelf[0]];
                        //設定主要Welf為第一隻
                    }
                }
                break;
            case 1 :
                {
                    if (mpMainWelf == null) {
                        mpMainWelf = mainWelf[chooseWelf[1]];
                        //設定主要Welf為第二隻
                    }
                }
                break;
        }
        for (int i = 0; i < mainWelf.Length; i++)
        {
            mainWelf[i].SetActive(false);
        }
        mpMainWelf.SetActive(true);
        //設定主要Welf為active
    }
}
