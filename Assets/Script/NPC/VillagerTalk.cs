using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class VillagerTalk : MonoBehaviour {
    private bool isclickZ;
    private bool isfungus;
    [SerializeField]
    private GameObject talkimage;
    [SerializeField]
    private float fhidespeed = 300f;
    [SerializeField]
    private Vector3 vr0;
    [SerializeField]
    private Vector3 vr1;
    [SerializeField]
    private Flowchart flowchart;
    // Use this for initialization
    void Start()
    {
        vr0 = talkimage.transform.position;
        vr1 = talkimage.transform.position + new Vector3(-fhidespeed, 0f, 0f);
        talkimage.transform.position = vr1; //隱藏talkimage
    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("isend") == true)
        { 
            isfungus = false;
            isclickZ = false;
            talkimage.transform.position = vr0;
            flowchart.SetBooleanVariable("isend",false);
            Debug.Log("d");
        }
        
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown("z") && isfungus == false && isclickZ == false)  //未對話時才可按下z
        {
            isclickZ = true;
            Debug.Log("c");
        }
        else if (isclickZ == false && isfungus == false&& flowchart.GetBooleanVariable("isplayer") == true)  //進入未動作
        {
            talkimage.transform.position = vr0; //顯示talkimage
            Debug.Log("b");
        }
        
        else if(isclickZ==true&&isfungus==false)  //對話
        {
            talkimage.transform.position = vr1; //隱藏talkimage
            Fungus.Flowchart.BroadcastFungusMessage(this.gameObject.name);
            isfungus = true;
            isclickZ = false;
            Debug.Log("a");
        }
        else if (isfungus == true && isclickZ == false && flowchart.GetBooleanVariable("isplayer") == true)
        {
            if (gameObject.name != "Odeliaspecial")
            {
                talkimage.transform.position = vr0;
                isfungus = false;
                Debug.Log(":");
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isfungus = false;
        isclickZ = false;
        talkimage.transform.position = vr1; //隱藏talkimage
        Debug.Log("f");
    }
}
