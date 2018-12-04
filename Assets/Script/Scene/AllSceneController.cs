﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllSceneController : MonoBehaviour
{
    [SerializeField]
    public static bool toprescene=false;
    [SerializeField]
    public static bool tonextscene = false;
    [SerializeField]
    public static int iscenenumber;
    private Scene scene;

    enum SCENE
    {
        START=0,
        HomeMama,
        Forest,
        VillageOne,
        HomeDad,
        VillageTwo,
        LaboratoryOne,
        LaboratoryTwo,
        LaboratoryThree,
    }
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        iscenenumber = scene.buildIndex;
    }
    private void Update()
    {
        if (iscenenumber>(int)SCENE.LaboratoryOne&& toprescene)    //在關卡LaboratoryOne前沒有回到前一個場景的機制
        {
            iscenenumber -= 1;
            SceneManager.LoadScene(iscenenumber);
            toprescene = !toprescene;

        }
        else if(tonextscene)    
        {
            iscenenumber += 1;
            if (iscenenumber==6|| iscenenumber == 8)
            {
                SceneManager.LoadScene("ChooseElfMenu");
            }
            else
            {
                SceneManager.LoadScene(iscenenumber);
            }
            tonextscene = !tonextscene;
        }
    }


}