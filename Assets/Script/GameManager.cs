using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //設定介面未做
    static GameManager instance;
    public GameObject Setmenu;
    public GameObject Exitagree;

    [SerializeField]
    private bool issetmenu = false;
    [SerializeField]
    private bool isgameexit = false;
    [SerializeField]
    private bool isexitagree = false;
    public int ihidespeed;

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
        Setmenu.transform.position += new Vector3(-ihidespeed, 0f, 0f); //隱藏Setmenu
        Exitagree.transform.position += new Vector3(-ihidespeed, 0f, 0f); //隱藏Exitagree
    }
    void Update()
    {
        if(Input.GetKeyDown("escape"))   //當按下esc要出現設定介面canvas
        {
            issetmenu = !issetmenu;
            LoadSetCanvas();
        }
        if (isexitagree)
        {
            Exitagree.transform.position -= new Vector3(-ihidespeed, 0f, 0f); //顯示Exitagree
            Debug.Log("aa");
        }
        if (isgameexit)     //choose 確認退出 become true
        {
            Application.Quit();
        }
        else if (!isgameexit)   //choose 取消退出 become false 回到選單
        {
            Exitagree.transform.position += new Vector3(-ihidespeed, 0f, 0f); //隱藏Exitagree
        }
        
    }
    private void LoadSetCanvas()  //出現設定介面
    {
        if(issetmenu)
            Setmenu.transform.position -= new Vector3(-ihidespeed, 0f, 0f); //顯示Setmenu
        else
            Setmenu.transform.position += new Vector3(-ihidespeed, 0f, 0f); //隱藏Setmenu
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