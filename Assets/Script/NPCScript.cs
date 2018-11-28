using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour {
    string npcname;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aa");
        npcname = this.gameObject.name;
        Fungus.Flowchart.BroadcastFungusMessage(npcname);
        Debug.Log(npcname);
    }
}
