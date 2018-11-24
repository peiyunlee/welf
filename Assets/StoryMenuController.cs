using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMenuController : AllSceneController
{
    public GameObject StoryMenu;
    public GameObject StoryMenuBtn;
    public GameObject ExitStoryimg;
    public GameObject OpenStoryimg;
    public float fhidespeed = 300f;
    [SerializeField]
    private bool isstorymenu = false;
    enum SCENE
    {
        START = 0,
        HomeMama,
        Forest,
        VillageOne,
        HomeDad,
        VillageTwo,
        LaboratoryOne,
        LaboratoryTwo,
        LaboratoryThree,
    }
    private void Awake()
    {
     
    }
    void Start()
    {
        
        if (AllSceneController::iscenenumber < (int)SCENE.LaboratoryOne)
        {
            StoryMenuBtn.transform.position += new Vector3(-fhidespeed, 0f, 0f); //隱藏StoryMenuBtn
            ExitStoryimg.transform.position += new Vector3(-fhidespeed, 0f, 0f); //隱藏ExitStoryimg
            OpenStoryimg.transform.position += new Vector3(-fhidespeed, 0f, 0f); //隱藏OpenStoryimg
            Debug.Log(AllSceneController.iscenenumber);
        }
        else
        {
            StoryMenuBtn.transform.position += new Vector3(0.0f, 0.0f, 0.0f); //顯示StoryMenuBtn
            OpenStoryimg.transform.position += new Vector3(0.0f, 0.0f, 0.0f); //顯示OpenStoryimg
            Debug.Log(2);
        }
    }

    void Update()
    {
    }
    public void OnStoryMenuBtnClick()
    {
        isstorymenu = !isstorymenu;
        if (isstorymenu)
        {
            StoryMenu.transform.position += new Vector3(0.0f, 0.0f, 0.0f); //顯示StoryMenu
            ExitStoryimg.transform.position += new Vector3(0.0f, 0.0f, 0.0f); //顯示ExitStoryimg
            OpenStoryimg.transform.position += new Vector3(-fhidespeed, 0f, 0f); //隱藏OpenStoryimg
            Debug.Log("1");
        }
        else
        {
            StoryMenu.transform.position += new Vector3(0.0f, 0.0f, 0.0f); //顯示StoryMenu
            OpenStoryimg.transform.position += new Vector3(0.0f, 0.0f, 0.0f); //顯示OpenStoryimg
            ExitStoryimg.transform.position += new Vector3(-fhidespeed, 0f, 0f); //隱藏ExitStoryimg
            Debug.Log("2");
        }
    }
}
