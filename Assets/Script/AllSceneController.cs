using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllSceneController : MonoBehaviour {
    [SerializeField]
    private bool toprescene=false;
    [SerializeField]
    private bool tonextscene = false;
    [SerializeField]
    private int iscenenumber=1;

    /*public void OnStartBtn()
    {
        SceneManager.LoadScene("HomeMama");
    }
    public void OnExitBtn()
    {
        Application.Quit();
    }*/
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
    private void Update()
    {
        if (iscenenumber>(int)SCENE.VillageTwo&&toprescene)    //在關卡VillageTwo前沒有回到前一個場景的機制
        {
            iscenenumber -= 1;
            SceneManager.LoadScene(iscenenumber);
            toprescene = !toprescene;
        }
        else if(tonextscene)     
        {
            iscenenumber += 1;
            SceneManager.LoadScene(iscenenumber);
            tonextscene = !tonextscene;
        }
    } 
        
    
}
