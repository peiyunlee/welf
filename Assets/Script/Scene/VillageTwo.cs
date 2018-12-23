using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class VillageTwo : MonoBehaviour
{
    [SerializeField]
    private Fungus.Flowchart flowchart;
    [SerializeField]
    private GameObject [] target;
    [SerializeField]
    public GameObject Playerwelf;
    public GameObject [] UIcanvas;
    // Use this for initialization
    void Start()
    {
        target[0].GetComponent<BoxCollider2D>().isTrigger = true;
        target[1].GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("isplayer") == true)
        {
            PlayerMovement.isMenu = false;
            target[0].GetComponent<BoxCollider2D>().isTrigger = false;
            target[1].GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else if (flowchart.GetBooleanVariable("isplayer") == false)
        {
            PlayerMovement.isMenu = true;
            target[0].GetComponent<BoxCollider2D>().isTrigger = true;
            target[1].GetComponent<BoxCollider2D>().isTrigger = true;
        }
        if (flowchart.GetBooleanVariable("getwelf") == true)
        {
            Playerwelf.SetActive(true);
            UIcanvas[0].SetActive(false);
            UIcanvas[1].SetActive(true);
        }
    }
}
