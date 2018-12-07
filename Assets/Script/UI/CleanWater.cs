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
    private GameObject textgameobject;
    [SerializeField]
    private Text cleanwatercounttext;
    [SerializeField]
    private bool istrigger;   //test
    [SerializeField]
    private bool isuse;   //test
    void Start () {
        cleanwatercount = 0;
        textgameobject = GameObject.Find("CleanWatertext");
        cleanwatercounttext = textgameobject.GetComponent<Text>();
        Render();
    }

    private void Update()   //test
    {
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
        Render();
        Debug.Log("bb");
    }

    public void DecreaseCleanWater()
    {
        cleanwatercount-= usecleanwater;
        Render();
    }
    private void Render()
    {
        cleanwatercounttext.text = "" + cleanwatercount;
    }
}
