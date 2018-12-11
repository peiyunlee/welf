using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class VillageOne : MonoBehaviour {
    [SerializeField]
    private Fungus.Flowchart flowchart;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private bool allhastalk;
    // Use this for initialization
    void Start () {
        target.GetComponent<BoxCollider2D>().isTrigger = true;
    }
	
	// Update is called once per frame
	void Update () {
        allhastalk = flowchart.GetBooleanVariable("hastalk1") && flowchart.GetBooleanVariable("hastalk2")
            && flowchart.GetBooleanVariable("hastalk3") && flowchart.GetBooleanVariable("hastalk4") && flowchart.GetBooleanVariable("hastalk5")
            && flowchart.GetBooleanVariable("hastalk6") && flowchart.GetBooleanVariable("hasodeliatalk");
        if (flowchart.GetBooleanVariable("isplayer") == true)
        {
            PlayerMovement.isMenu = false;
            target.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else if (flowchart.GetBooleanVariable("isplayer") == false)
        {
            PlayerMovement.isMenu = true;
            target.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        if (allhastalk)
        {
            flowchart.SetBooleanVariable("isplayer",false);
            Fungus.Flowchart.BroadcastFungusMessage("ToHomeDad");
            target.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
