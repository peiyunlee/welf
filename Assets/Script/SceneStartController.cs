using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStartController : MonoBehaviour {
    [SerializeField]
    private bool isgamestart=false;
    [SerializeField]
    private bool isgameexit= false;
    /*public void OnStartBtn()
    {
        SceneManager.LoadScene("HomeMama");
    }
    public void OnExitBtn()
    {
        Application.Quit();
    }*/

    enum SCENE{
        START,
        HomeMama,
        Forest,
        VillageOne,
        HomeDad,
        VillageTwo,
        LaboratoryOne,
        LaboratoryTwo,
        LaboratoryThree,
    }

    private void Update()
    {
        if (isgamestart)    //choose button start become true
        {
            SceneManager.LoadScene("HomeMama");
        }
        else if(isgameexit)     //choose button exit become true
        {
            Application.Quit();
        }
    } 
    public void OnStartBtnClick()
    {
        isgamestart = true;
    }
    public void OnContinueBtnClick()
    {
        
    }
    public void OnExitBtnClick()
    {
        isgameexit = true;
    }
}
