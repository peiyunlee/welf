using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class VillageTwo : MonoBehaviour
{
    public bool teach1;
    public bool teach2;
    public bool teach3;
    [SerializeField]
    private Fungus.Flowchart flowchart;
    [SerializeField]
    private GameObject [] target;
    public GameObject StoryMenu;
    [SerializeField]
    public GameObject Playerwelf;
    public GameObject [] UIcanvas;
    public GameObject[] welf;
    public GameObject playerattackscript;
    public static bool getwelf;
    private PlayerAttack playerattack;
    // Use this for initializationl
    void Start()
    {
        target[0].GetComponent<BoxCollider2D>().isTrigger = true;
        target[1].GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("isplayer") == true&&!flowchart.GetBooleanVariable("istwoend"))
        {
            PlayerMovement.isMenu = false;
            target[0].GetComponent<BoxCollider2D>().isTrigger = false;
            target[1].GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else if (flowchart.GetBooleanVariable("isplayer") == false)
        {
            PlayerMovement.isMenu = true;
        }
        if (flowchart.GetBooleanVariable("getwelf") == true)
        {
            getwelf = true;
            GameManager.cleanwatercount = CleanWater.cleanwatercount;
            UIcanvas[0].SetActive(false);
            UIcanvas[1].SetActive(true);
            playerattackscript.SetActive(true);
        }
        if (flowchart.GetBooleanVariable("isteach") == true&&!teach1)
        {
            if (PlayerAttack.keyAttack)
            {
                flowchart.SetBooleanVariable("isplayer", false);
                teach1 = true;
                flowchart.SetBooleanVariable("isteach", false);
                Fungus.Flowchart.BroadcastFungusMessage("welfteach2");
            }
        }
        if (flowchart.GetBooleanVariable("isteachskill") == true )
        {
            if (SkillSet.keySkill && !teach2)
            {
                teach2 = true;
                flowchart.SetBooleanVariable("isteach", false);
                Fungus.Flowchart.BroadcastFungusMessage("SkillTeach3");
            }
            else if (Input.GetKeyDown(KeyCode.A) && !teach3)
            {
                teach3 = true;
                flowchart.SetBooleanVariable("isteach", false);
                Fungus.Flowchart.BroadcastFungusMessage("SkillTeach4");
            }
        }
        if (flowchart.GetBooleanVariable("istwoend"))
        {
            target[1].GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    public void Welfdisappear()
    {
        welf[GameManager.chooseelf[0] - 1].SetActive(false);
        welf[GameManager.chooseelf[1] - 1].SetActive(false);
    }
}
