using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseElfController : AllSceneController
{
    public GameObject Chooseagreemenu;
    [SerializeField]
    bool[] isbeingchoosed = new bool[3];  //水精靈已被選擇
    [SerializeField]
    int[] chooseelf= new int[2];
    [SerializeField]
    int count=0;
    enum ELF
    {
        Tender = 0,
        Acute,
        Vigorous,
    }
    // Use this for initialization
    void Start () {
       Chooseagreemenu.transform.position += new Vector3(-1000, 0f, 0f); //隱藏chooseagree
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnElfBtnClick(int elfnumber)  //當任一按鈕被按下傳送該按鈕號碼
    {
        if (isbeingchoosed[elfnumber]&&count<2)  //已被選擇過且沒滿
        {
            count--;
            isbeingchoosed[elfnumber] = false;
            //取消選擇
        }
        else if (!isbeingchoosed[elfnumber] && count < 2) //還沒被選擇過且沒滿
        {
            count++;
            isbeingchoosed[elfnumber] = true;
            //選擇
        }
        else if (count==2)
        {
            count++;
            Chooseagreemenu.transform.position += new Vector3(1000, 0f, 0f); //顯示chooseagree
        }
    }
    public void OnYesBtnClick()
    {
        SceneManager.LoadScene(iscenenumber);
    }
    public void OnBackBtnClick()
    {
        Chooseagreemenu.transform.position += new Vector3(-1000, 0f, 0f); //隱藏chooseagree
        count = 0;
        for (int i = 0; i < 3; i++)
        {
            isbeingchoosed[i] = false;//重置所有選擇
            //取消所有選擇
        }
       
    }
}
