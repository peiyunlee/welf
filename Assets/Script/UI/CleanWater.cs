using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanWater : MonoBehaviour {
    [SerializeField]
    private int cleanwatercount;
    [SerializeField]
    private int usecleanwater;
    [SerializeField]
    private Text cleanwatercounttext;
    [SerializeField]
    private bool istrigger;   //test
    [SerializeField]
    private bool isuse;   //test

    void Start () {
        cleanwatercount = 0;
        
    }

    private void Update()   //test
    {
        cleanwatercounttext.text = "" + cleanwatercount;
        if (istrigger)
        {
            AddCleanWater();
            istrigger = false;
        }
        if (isuse)
        {
            DecreaseCleanWater();
            isuse = false;
        }
    }

    public void AddCleanWater ()
    {
        cleanwatercount++;
    }

    public void DecreaseCleanWater()
    {
        cleanwatercount-= usecleanwater;
    }
}
