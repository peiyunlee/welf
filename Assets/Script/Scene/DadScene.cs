using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadScene : MonoBehaviour {
    [SerializeField]
    private Fungus.Flowchart flowchart;
    [SerializeField]
    private GameObject []target;
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
        if (flowchart.GetBooleanVariable("isstart") == true)
        {
            target[0].GetComponent<BoxCollider2D>().isTrigger = false;
            target[1].GetComponent<BoxCollider2D>().isTrigger = false;
        }
        if (flowchart.GetBooleanVariable("isend") == true)
        {
            target[1].GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
