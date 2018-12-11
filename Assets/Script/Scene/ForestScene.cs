using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestScene : MonoBehaviour {
    [SerializeField]
    private Fungus.Flowchart flowchart;
    void Update()
    {
        if (flowchart.GetBooleanVariable("isplayer") == true)
        {
            PlayerMovement.isMenu = false;
        }
        else
        {
            PlayerMovement.isMenu = true;
        }
        
    }
}
