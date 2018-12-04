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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.name == "NextSceneDoor")
        {
            AllSceneController.tonextscene = true;
            Debug.Log("a");
            Debug.Log(AllSceneController.tonextscene);
        }
        else if (this.name == "PreSceneDoor")
        {
            AllSceneController.toprescene = true;
            Debug.Log("b");
            Debug.Log(AllSceneController.tonextscene);
        }
        
    }
}
