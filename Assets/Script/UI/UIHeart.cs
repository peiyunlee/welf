using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeart: MonoBehaviour {
    public GameObject[] lifelove;
    public GameObject[] lifeloveout;
    public int testcurrentHealth = 20;     //test
    [SerializeField]
    public bool testishurt = false;
    [SerializeField]
    public bool testisbox = false;
    Animator anim;
    void Update()
    {
        if (testishurt)  //test  生命上限
        {
            testcurrentHealth--;
            DecreaseLife(testcurrentHealth);
            testishurt = false;
        }
        if (testisbox)  //test
        {
            testcurrentHealth++;
            AddLife(testcurrentHealth);
            testisbox = false;
        }
    }
    public void DecreaseLife(int playercurrentHealth)
    {
        anim = lifelove[playercurrentHealth].GetComponent<Animator>();
        anim.SetTrigger("Disappear");
    }
    public void AddLife(int playercurrentHealth)
    {
        testcurrentHealth++;  //test
        anim = lifelove[playercurrentHealth].GetComponent<Animator>();
        anim.SetTrigger("Add");
        Debug.Log("AddLife");
    }

}
