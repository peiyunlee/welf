using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestScene : MonoBehaviour {
    [SerializeField]
    private Fungus.Flowchart flowchart;
    [SerializeField]
    private GameObject target;
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
        if (flowchart.GetBooleanVariable("isteach1") == true)
        {
            if (PlayerMovement.jumpCount == 1)
            {
                flowchart.SetBooleanVariable("isteach1", false);
                Fungus.Flowchart.BroadcastFungusMessage("TeachJump2");
            }
        }
        else if (flowchart.GetBooleanVariable("isteach2") == true)
        {
            if (PlayerMovement.jumpCount == 2)
            {
                flowchart.SetBooleanVariable("isteach2", false);
                target.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
    }
}
