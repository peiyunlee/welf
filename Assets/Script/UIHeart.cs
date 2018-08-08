using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeart: MonoBehaviour {
    public GameObject[] lifelove;
    public int testcurrentHealth=12;     //test
    [SerializeField]
    private int lasttimehealth=12;

    
    Animator anim;
    void Update()           //test
    {
        if (testcurrentHealth != 12)
        {
            DecreaseLife(testcurrentHealth);
        }
    
    }

    public void DecreaseLife(int playercurrentHealth)
    {
        for (int i = lasttimehealth; i > playercurrentHealth; i--)
        {
            anim = lifelove[i - 1].GetComponent<Animator>();
            anim.SetTrigger("Disappear");
        }
        lasttimehealth = playercurrentHealth;
    }

}
