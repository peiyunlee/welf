using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countAllEnemy : MonoBehaviour {


    public bool littleEnemy1_allDead = false;
    public bool littleEnemy2_allDead = false;
    public bool middleEnemy_allDead = false;

    public int littleEnemy1_count = 1;
    public int littleEnemy2_count = 10;
    public int middleEnemy_count = 1;


    // Update is called once per frame
    void Update()
    {
        
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
