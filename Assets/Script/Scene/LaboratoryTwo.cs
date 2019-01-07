using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaboratoryTwo : MonoBehaviour {
    public bool testisbossdie;  //testboss
    public int testenemycount = 20;  //小怪 只要有一隻死掉enemycount--   test
    //public Button bossstorybtn;
    public GameObject bossstorybtn;
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
        if (Enemy_count.middleEnemy_allDead)    //boss死掉
        {
            BossTalk.bosscantalk = true;
            //bossstorybtn.interactable = true;
            bossstorybtn.SetActive(true);
        }
        if (testenemycount == 0&& flowchart.GetBooleanVariable("bosshastalk"))
        {
            gamefinish = true;
            for (int i = 0; i < 2; i++)
            {
                wall[i].isTrigger = true;
            }
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
