using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetmenuController : MonoBehaviour {
    //設定介面未做
    public GameObject Setmenu;
    public GameObject Exitagreemenu;

    [SerializeField]
    private bool issetmenu = false;
    [SerializeField]
    private bool isgameexit = false;    //確認退出是否
    [SerializeField]
    private bool isbeingshowagreemenu = false;
    [SerializeField]
    private bool isexitagreemenu = false;   //exitagreemenu出現
    [SerializeField]
    private bool isclick = false;   //暫時判斷確認退出的判斷按鈕按下
    private float fhidespeed=300f;
    private float fz = 10f;

    private void Start()
    {
        Setmenu.transform.position += new Vector3(-fhidespeed, 0f, 0f); //隱藏Setmenu
        Exitagreemenu.transform.position += new Vector3(-fhidespeed, 0f, 0f); //隱藏Exitagree
    }
    void Update()
    {
        if (Input.GetKeyDown("escape"))   //當按下esc要出現設定介面canvas
        {
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
            Setmenu.transform.position = new Vector3(0.0f, 0.0f, fz); //顯示Setmenu
        }
        else
        {
            Setmenu.transform.position = new Vector3(-fhidespeed, 0f, fz); //隱藏Setmenu
            Exitagreemenu.transform.position = new Vector3(-fhidespeed, 0f, fz); //隱藏Exitagree
            isexitagreemenu = false;
            isbeingshowagreemenu = false;
        }
    }
    private void LoadExitagreeCanvas()  //出現是否退出的介面
    {
        Exitagreemenu.transform.position = new Vector3(0f, 1f, fz); //顯示Exitagree
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
            Exitagreemenu.transform.position += new Vector3(-fhidespeed, 0f, fz); //隱藏Exitagree
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
        isclick = true;
    }
    
}
