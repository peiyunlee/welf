using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanWater : MonoBehaviour {
    [SerializeField]
    public static int cleanwatercount;
    [SerializeField]
    private int usecleanwater;
    [SerializeField]
    private GameObject textgameobject;
    [SerializeField]
    private Text cleanwatercounttext;
    [SerializeField]
    private bool isuse;   //test
    void Start () {
        cleanwatercount = GameManager.cleanwatercount;
        textgameobject = GameObject.Find("CleanWatertext");
        cleanwatercounttext = textgameobject.GetComponent<Text>();
        Render();
    }

    private void Update()   //test
    {
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
