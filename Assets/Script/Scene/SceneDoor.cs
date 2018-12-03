using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDoor : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTrigger2D(Collision2D collision)
    {
        Debug.Log("3");
        if (this.name == "NextSceneDoor")
        {
            AllSceneController.tonextscene = true;
            Debug.Log(AllSceneController.tonextscene);
        }
        else if (this.name == "PreSceneDoor")
        {
            AllSceneController.toprescene = true;
            Debug.Log(AllSceneController.toprescene);
        }
        
    }
}
