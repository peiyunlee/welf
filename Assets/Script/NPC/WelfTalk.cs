using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class WelfTalk : MonoBehaviour {
    private bool isclickZ;
    private bool isfungus;
    [SerializeField]
    private GameObject [] talkimage;
    [SerializeField]
    private float fhidespeed = 300f;
    [SerializeField]
    private Vector3 [] vr0;
    [SerializeField]
    private Vector3 [] vr1;
    [SerializeField]
    private Flowchart flowchart;
    int count;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            vr0[i] = talkimage[i].transform.position;
            vr1[i] = talkimage[i].transform.position + new Vector3(-fhidespeed, 0f, 0f);
            talkimage[i].transform.position = vr1[i]; //隱藏talkimage
            count = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("isteachend") == true)
        {
            isfungus = false;
            isclickZ = false;
            count++;
            if(count<=2)
                talkimage[count].transform.position = vr0[count];
            flowchart.SetBooleanVariable("isteachend", false);
        }


    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (count <= 2&& flowchart.GetBooleanVariable("welftalk") == true)
        {
            if (Input.GetKeyDown("z") && isfungus == false && isclickZ == false)  //未對話時才可按下z
            {
                isclickZ = true;
                if (isclickZ == true)  //對話
                {
                    talkimage[count].transform.position = vr1[count]; //隱藏talkimage
                    Fungus.Flowchart.BroadcastFungusMessage("welftalk");
                    isfungus = true;
                }
            }
            else if (isclickZ == false && isfungus == false && flowchart.GetBooleanVariable("isplayer") == true)  //進入未動作
            {
                talkimage[count].transform.position = vr0[count]; //顯示talkimage
            }

            //else if (isclickZ == true && isfungus == false)  //對話
            //{
            //    talkimage[count].transform.position = vr1[count]; //隱藏talkimage
            //    Fungus.Flowchart.BroadcastFungusMessage("welftalk");
            //    isfungus = true;
            //}
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (count <= 2) 
            talkimage[count].transform.position = vr1[count]; //隱藏talkimage
    }
}
