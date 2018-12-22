using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaboratoryOne : MonoBehaviour {
    bool isbossdie;  //boss
    public int testenemycount = 15;  //小怪 只要有一隻死掉enemycount--
    [SerializeField]
    private Fungus.Flowchart flowchart;
    [SerializeField]
    private bool gamefinish = false;
    [SerializeField]
    private Collider2D[] wall;
    void Start () {
        wall[0] = GameObject.Find("Rwall").GetComponent<Collider2D>();
        wall[1] = GameObject.Find("Lwall").GetComponent<Collider2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (testenemycount == 0)
        {
            gamefinish = true;
            for (int i = 0; i < 2; i++)
            {
                wall[i].isTrigger = true;
            }
            Fungus.Flowchart.BroadcastFungusMessage("DoorOpen");
        }
        if (flowchart.GetBooleanVariable("isstart") == true)
        {
            for (int i = 0; i < 2; i++)
            {
                wall[i].isTrigger = false;
            }
        }
    }
}
