using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {
    bool isbossdie;
    int count;

    [SerializeField]
    public static bool gamefinish=false;
    [SerializeField]
    private Fungus.Flowchart flowchart;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isbossdie)    //boss死掉
        {
            flowchart.SetBooleanVariable("bosscantalk", true);
        }
        if (isbossdie && count == 0)
        {
            gamefinish = true;
        }
	}
}
