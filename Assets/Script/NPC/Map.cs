using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Map : MonoBehaviour {
    public Animator anim;
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
        anim.speed = 0.5f;
        Debug.Log(anim.speed);
    }
    // Update is called once per frame
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
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown("z") && isclickZ == false)
        {
            isclickZ = true;
            talkimage.transform.position = vr1; //隱藏talkimage
            if (isfungus == false)
            {
                talkimage.transform.position = vr1; //隱藏talkimage
                Fungus.Flowchart.BroadcastFungusMessage(gameObject.name);
                isfungus = true;
                PlayerMovement.isMenu = true;//主角不行動
            }
        }
        if (isclickZ == false && isfungus == false)
        {
            talkimage.transform.position = vr0; //顯示talkimage
        }
        else
        {
            talkimage.transform.position = vr1; //隱藏talkimage
            //if (isfungus == false)
            //    Fungus.Flowchart.BroadcastFungusMessage(gameObject.name);
            //isfungus = true;
            //PlayerMovement.isMenu = true;//主角不行動
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isfungus = false;
        isclickZ = false;
        talkimage.transform.position = vr1; //隱藏talkimage
    }
}
