using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHeart: MonoBehaviour {
    public GameObject[] lifelove;
    public GameObject[] lifeloveout;
    public int testcurrentHealth = 20;    //test
    public int Scenestarthealth;    
    [SerializeField]
    public bool testishurt = false;   //test
    [SerializeField]
    public bool testisbox = false;   //test
    Animator anim;
    private void Start()
    {
        Scenestarthealth = GameManager.playercurrenthealth;
        for (int i = 20; i > Scenestarthealth; i--)
        {
            anim = lifelove[i-1].GetComponent<Animator>();
            anim.SetTrigger("notshow");
        }
    }
    void Update()
    {
        //if (testishurt)  //test  生命上限
        //{
        //    testcurrentHealth--;
        //    DecreaseLife(testcurrentHealth);
        //    testishurt = false;
        //}
        //if (testisbox)  //test
        //{
        //    testcurrentHealth++;
        //    AddLife(testcurrentHealth);
        //    testisbox = false;
        //}
    }
    public void DecreaseLife(int playercurrentHealth)
    {
        anim = lifelove[playercurrentHealth].GetComponent<Animator>();
        anim.SetTrigger("Disappear");
    }
    public void AddLife(int playercurrentHealth)
    {
        //testcurrentHealth++;  //test
        PlayerHealth.currentHealth++;
        if (PlayerHealth.currentHealth > 20)
        {
            PlayerHealth.currentHealth = 20;
        }
        anim = lifelove[playercurrentHealth++].GetComponent<Animator>();
        anim.SetTrigger("Add");
        
    }

}
