using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class BossTalk : MonoBehaviour
{
    private bool isclickZ;
    private bool isfungus;
    [SerializeField]
    private GameObject talkimage;
    [SerializeField]
    private Flowchart flowchart;
    public static bool bosscantalk;
    // Use this for initialization
    void Start()
    {
        talkimage.SetActive(false); //隱藏talkimage
        bosscantalk = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("bosscantalk"+bosscantalk);
        if (flowchart.GetBooleanVariable("isplayer") == true)
            PlayerMovement.isMenu = false;//主角不行動
        else
            PlayerMovement.isMenu = true;//主角行動
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (bosscantalk == true)
        {
            if (Input.GetKeyDown("z") && isfungus == false && isclickZ == false)
            {
                isclickZ = true;
            }
            if (isclickZ == false && isfungus == false)
            {
                talkimage.SetActive(true); //顯示talkimage
            }
            else
            {
                talkimage.SetActive(false); //隱藏talkimage
                if (isfungus == false)
                    Fungus.Flowchart.BroadcastFungusMessage("Boss");
                isfungus = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (bosscantalk == true)
        {
            isfungus = false;
            isclickZ = false;
            talkimage.SetActive(false); //隱藏talkimage
        }
    }
}
