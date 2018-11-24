using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMenuController : MonoBehaviour
{
    public GameObject StoryMenu;
    public GameObject StoryMenuBtn;
    public GameObject ExitStoryimg;
    public GameObject OpenStoryimg;
    [SerializeField]
    private Vector3 vr0;
    [SerializeField]
    private Vector3 vr1;
    public float fhidespeed = 300f;
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
        vr0= StoryMenuBtn.transform.position;
        vr1 = StoryMenuBtn.transform.position + new Vector3(-fhidespeed, 0f, 0f);
        StoryMenu.transform.position += new Vector3(-fhidespeed, 0.0f, 0.0f); //隱藏StoryMenu
        StoryMenuBtn.transform.position = vr1; //隱藏StoryMenuBtn
        ExitStoryimg.transform.position = vr1; //隱藏ExitStoryimg
        OpenStoryimg.transform.position = vr1; //隱藏OpenStoryimg
    }

    void Update()
    {
        if (AllSceneController.iscenenumber < (int)SCENE.LaboratoryOne)
        {
            StoryMenuBtn.transform.position = vr1; //隱藏StoryMenuBtn
            ExitStoryimg.transform.position = vr1; //隱藏ExitStoryimg
            OpenStoryimg.transform.position = vr1; //隱藏OpenStoryimg
            Debug.Log(AllSceneController.iscenenumber);
        }
        else
        {
            StoryMenuBtn.transform.position = vr0; //顯示StoryMenuBtn
            OpenStoryimg.transform.position = vr0; //顯示OpenStoryimg
            Debug.Log(2);
        }
    }
    public void OnStoryMenuBtnClick()
    {
        isstorymenu = !isstorymenu;
        if (isstorymenu)
        {
            StoryMenu.transform.position += new Vector3(fhidespeed, 0.0f, 0.0f); //顯示StoryMenu
            ExitStoryimg.transform.position = vr0; //顯示ExitStoryimg
            OpenStoryimg.transform.position = vr1; //隱藏OpenStoryimg
            Debug.Log("1");
        }
        else
        {
            StoryMenu.transform.position += new Vector3(-fhidespeed, 0.0f, 0.0f); //隱藏StoryMenu
            OpenStoryimg.transform.position = vr0; //顯示OpenStoryimg
            ExitStoryimg.transform.position = vr1; //隱藏ExitStoryimg
            Debug.Log("2");
        }
    }
}
