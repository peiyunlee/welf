﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    static GameManager instance;
    public GameObject Setmenu; 
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
        Setmenu = GameObject.Find("Setmenu");
        Setmenu.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown("escape"))   //當按下esc要出現設定介面canvas
        {
            LoadSetCanvas();
        }
    }

    private void LoadSetCanvas()  //出現設定介面
    {
        Setmenu.SetActive(true);
    }


    //Button
    public void OnYesExitBtn() //確認退出
    {
        Application.Quit();
    }

    public void OnNoExitBtn() //取消退出
    {
        //回到設定介面
    }
}