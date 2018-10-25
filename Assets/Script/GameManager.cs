using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //設定介面未做
    static GameManager instance;
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
    public float fhidespeed;

    void Awake()
    {
        if (instance == null)   //當第一個GameManager出現不要destroy
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance)  //當第二個GameManager出現刪除
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Setmenu.transform.position += new Vector3(-fhidespeed, 0f, 0f); //隱藏Setmenu
        Exitagreemenu.transform.position += new Vector3(-fhidespeed, 0f, 0f); //隱藏Exitagree
    }
    void Update()
    {
        if(Input.GetKeyDown("escape"))   //當按下esc要出現設定介面canvas
        {
            issetmenu = !issetmenu;
            LoadSetCanvas();
        }
        if (isexitagreemenu&&isbeingshowagreemenu==false)    //按下按鈕isexitagreemenu=true且還沒顯示exitagreemenu要出現exitagreemenu
        {
            LoadExitagreeCanvas(); //顯示Exitagree
        }
        if(isexitagreemenu)
        {
            Exitagree();
        }
    }
    private void LoadSetCanvas()  //出現設定介面
    {
        if(issetmenu)
            Setmenu.transform.position = new Vector3(0.0f, 0.0f, 0.0f); //顯示Setmenu
        else
            Setmenu.transform.position = new Vector3(-fhidespeed, 0f, 0f); //隱藏Setmenu
    }
    private void LoadExitagreeCanvas()  //出現是否退出的介面
    {
        Exitagreemenu.transform.position += new Vector3(fhidespeed, 0f, 0f); //顯示Exitagree
        isbeingshowagreemenu = true;    //已經顯示Exitagree
    }
    private void Exitagree()  //確認退出的判斷
    {
        if (isgameexit)     //choose 確認退出 become true
        {
            Application.Quit();
        }
        else if (!isgameexit)   //choose 取消退出 become false 回到選單
        {
            Exitagreemenu.transform.position += new Vector3(-fhidespeed, 0f, 0f); //隱藏Exitagree
            isexitagreemenu = false;
        }
    }

    /*//Button
    public void OnYesExitBtn() //確認退出
    {
        Application.Quit();
    }
    public void OnNoExitBtn() //取消退出
    {
        //回到設定介面
    }
    */
}