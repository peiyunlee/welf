using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_count : MonoBehaviour {

    public static bool littleEnemy1_allDead = false;
    public static bool littleEnemy2_allDead = false;
    public bool middleEnemy_allDead = false;

    public int littleEnemy1_count;
    public int littleEnemy2_count;
    public int middleEnemy_count;


    // Update is called once per frame
    void Update()
    {
        Debug.Log("middleEnemy_allDead" + middleEnemy_allDead);
        if (littleEnemy1_count == 0)
        {
            littleEnemy1_allDead = true;


        }
        if (littleEnemy2_count == 0)
        {
            littleEnemy2_allDead = true;


        }
        if (middleEnemy_count == 0)
        {
            middleEnemy_allDead = true;
        }
    }
}
