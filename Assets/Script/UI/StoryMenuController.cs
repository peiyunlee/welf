using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMenuController : MonoBehaviour
{
    public GameObject StoryMenu;
    public GameObject StoryMenuBtn;
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
        vr1 = vr0 + new Vector3(-fhidespeed, 0f, 0f);
        StoryMenu.transform.position += new Vector3(-fhidespeed, 0.0f, 0.0f); //隱藏StoryMenu
        StoryMenuBtn.transform.position =vr1; //隱藏StoryMenuBtn
    }

    void Update()
    {
        if (AllSceneController.iscenenumber < (int)SCENE.LaboratoryOne)
        {
            StoryMenuBtn.transform.position = vr1; //隱藏StoryMenuBtn
            Debug.Log(AllSceneController.iscenenumber);
        }
        else
        {
            StoryMenuBtn.transform.position = vr0; //顯示StoryMenuBtn
            Debug.Log("VR0");
        }
    }
    public void OnStoryMenuBtnClick()
    {
        isstorymenu = !isstorymenu;
        if (isstorymenu)
        {
            StoryMenu.transform.position += new Vector3(fhidespeed, 0.0f, 0.0f); //顯示StoryMenu
            Debug.Log("1");
        }
        else
        {
            StoryMenu.transform.position += new Vector3(-fhidespeed, 0.0f, 0.0f); //隱藏StoryMenu
            Debug.Log("2");
        }
    }
}
