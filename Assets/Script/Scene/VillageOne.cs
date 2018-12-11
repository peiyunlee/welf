using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageOne : MonoBehaviour {
    [SerializeField]
    private Fungus.Flowchart flowchart;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
