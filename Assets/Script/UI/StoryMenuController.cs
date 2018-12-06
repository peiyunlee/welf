using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject StoryMenu;
    [SerializeField]
    private GameObject StoryMenuBtn;
    [SerializeField]
    private bool isstorymenu = false;
    [SerializeField]
    private int count;
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
        StoryMenu.SetActive(false); //隱藏StoryMenu
        StoryMenuBtn.SetActive(false); //隱藏StoryMenuBtn
    }

    void Update()
    {
        if (AllSceneController.iscenenumber < (int)SCENE.LaboratoryOne)
        {
            StoryMenuBtn.SetActive(false); //隱藏StoryMenuBtn
            Debug.Log(AllSceneController.iscenenumber);
        }
        else
        {
            StoryMenuBtn.SetActive(true); //顯示StoryMenuBtn
        }
    }
    public void OnStoryMenuBtnClick()
    {
        isstorymenu = !isstorymenu;
        if (isstorymenu)
        {
            StoryMenu.SetActive(true); //顯示StoryMenu
        }
        else
        {
            StoryMenu.SetActive(false); //隱藏StoryMenu
        }
        
    }
}
