using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeart: MonoBehaviour {
    public GameObject[] lifelove;
    public int testcurrentHealth=12;
    [SerializeField]
    private int lasttimehealth=12;

    UIHeartDisappear uIHeartDisappear;

    void Update()           //test
    {
        if (testcurrentHealth != 12)
        {
            DecreaseLife(testcurrentHealth);
        }
    
    }
    public void DecreaseLife(int playercurrentHealth) {
        for (int i = lasttimehealth; i > playercurrentHealth; i--)
        {
            uIHeartDisappear = lifelove[i - 1].GetComponent<UIHeartDisappear>();
            uIHeartDisappear.AnimControl();
            //lifelove[i-1].SetActive(false);
        }
        lasttimehealth = playercurrentHealth;
    }
        
}
