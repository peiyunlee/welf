using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetmenuController : MonoBehaviour {
    //設定介面未做
    [SerializeField]
    private GameObject Setmenu;
    [SerializeField]
    private GameObject Exitagreemenu;
    [SerializeField]
    private bool issetmenu = false;
    [SerializeField]
    private bool isgameexit = false;    //確認退出是否
    [SerializeField]
    private bool isbeingshowagreemenu = false;
    [SerializeField]
    private static bool isexitagreemenu = false;   //exitagreemenu出現
    [SerializeField]
    private bool isclick = false;   //暫時判斷確認退出的判斷按鈕按下
    private void Start()
    {
        Setmenu.SetActive(false);
        Exitagreemenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown("escape"))   //當按下esc要出現設定介面canvas
        {
            Time.timeScale = 0f;
            issetmenu = !issetmenu;
            LoadSetCanvas();
        }
        if (isexitagreemenu && isbeingshowagreemenu == false)    //按下按鈕isexitagreemenu=true且還沒顯示exitagreemenu要出現exitagreemenu
        {
            LoadExitagreeCanvas(); //顯示Exitagree
        }
        if (isexitagreemenu)
        {
            Exitagree();
        }
    }
    private void LoadSetCanvas()  //出現設定介面
    {
        if (issetmenu)
        {
            Setmenu.SetActive(true);
            Exitagreemenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            Setmenu.SetActive(false); //隱藏Setmenu
            Exitagreemenu.SetActive(false); //隱藏Exitagree
            isexitagreemenu = false;
            isbeingshowagreemenu = false;
        }
    }
    private void LoadExitagreeCanvas()  //出現是否退出的介面
    {
        Exitagreemenu.SetActive(true); //顯示Exitagree
        isbeingshowagreemenu = true;    //已經顯示Exitagree
    }
    private void Exitagree()  //確認退出的判斷
    {
        if (isgameexit && isclick)     //choose 確認退出 become true
        {
            Application.Quit();
        }
        else if ((!isgameexit) && isclick)   //choose 取消退出 become false 回到選單
        {
            Exitagreemenu.SetActive(false); //隱藏Exitagree
            isexitagreemenu = false;
            isbeingshowagreemenu = false;
            isclick = false;
        }
    }

    //Button
    public void OnExitGameBtnClick() //取消退出
    {
        isexitagreemenu = true;
    }
    public void OnYesExitBtnClick() //確認退出
    {
        isgameexit = true;
        isclick = true;
    }
    public void OnCancelExitBtnClick() //取消退出
    {
        isgameexit = false;
        isclick = true;
    }
    
}
