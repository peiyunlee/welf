using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaboratoryTwo : MonoBehaviour {
    bool isbossdie;  //boss
    public int enemycount=20;  //小怪 只要有一隻死掉enemycount--
    [SerializeField]
    private bool gamefinish = false;
    [SerializeField]
    private Collider2D[] wall;
    [SerializeField]
    private Fungus.Flowchart flowchart;
    // Use this for initialization
    void Start () {
        wall[0] = GameObject.Find("Rwall").GetComponent<Collider2D>();
        wall[1] = GameObject.Find("Lwall").GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isbossdie)    //boss死掉
        {
            flowchart.SetBooleanVariable("bosscantalk", true);
        }
        if (isbossdie && enemycount == 0)
        {
            gamefinish = true;
            for (int i = 0; i < 2; i++)
            {
                wall[i].isTrigger = true;
            }
        }
    }
}
