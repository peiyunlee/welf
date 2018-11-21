using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseElfController : MonoBehaviour
{
    public GameObject Chooseagreemenu;
    [SerializeField]
    bool[] isbeingchoosed = new bool[3];  //水精靈已被選擇
    [SerializeField]
    int[] chooseelf= new int[2];
    [SerializeField]
    int count = 0;

    enum ELF
    {
        Tender = 1,
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
        if (isbeingchoosed[elfnumber-1]&&count<2)  //已被選擇過且沒滿
        {
            count--;
            isbeingchoosed[elfnumber-1] = false;
            for (int i = 0; i <2; i++)
            {
                if (chooseelf[i] == elfnumber) chooseelf[i] = 0;
            }
            //取消選擇
        }
        else if (!isbeingchoosed[elfnumber-1] && count < 2) //還沒被選擇過且沒滿
        {
            count++;
            isbeingchoosed[elfnumber-1] = true;
            chooseelf[count - 1] = elfnumber;
            //選擇
        }
        if (count==2)
        {
            Chooseagreemenu.transform.position += new Vector3(1000, 0f, 0f); //顯示chooseagree
        }
    }
    public void OnYesBtnClick()
    {
        SceneManager.LoadScene(AllSceneController.iscenenumber);
    }
    public void OnBackBtnClick()
    {
        Chooseagreemenu.transform.position += new Vector3(-1000, 0f, 0f); //隱藏chooseagree
        count = 0;
        for (int i = 0; i < 3; i++)
        {
            isbeingchoosed[i] = false;//重置所有選擇
            if(i<2) chooseelf[i] = 0;
            //取消所有選擇
        }
       
    }
}
