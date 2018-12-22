using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WELFUI : MonoBehaviour {
    [SerializeField]
    GameObject [] gameobject;
    [SerializeField]
    Image [] myImage;
    [SerializeField]
    Animator [] anim;
    [SerializeField]
    private int [] mychooseelf;
    [SerializeField]
    public int whitchelftest;  //test player use whitchelf
    [SerializeField]
    public bool ischangetest;  //test
    // Use this for initialization
    void Start () {
        anim[0]=gameobject[0].GetComponent<Animator>();
        anim[1] = gameobject[1].GetComponent<Animator>();
        mychooseelf[0] = 3;
        mychooseelf[1] = 2;
        ischangetest = true;
        whitchelftest = 1;
        anim[0].SetTrigger(mychooseelf[0] + "tobig");
        anim[1].SetTrigger(mychooseelf[1] + "tosmall");
        //myImage[0].sprite = Resources.Load("Images/UI/遊戲頭像/" + mychooseelf[0] + "_C", typeof(Sprite)) as Sprite;
        //myImage[1].sprite = Resources.Load("Images/UI/遊戲頭像/" + mychooseelf[1] + "_H", typeof(Sprite)) as Sprite;
        //myImage[2].sprite = Resources.Load("Images/UI/遊戲頭像/" + mychooseelf[0] + "_CS", typeof(Sprite)) as Sprite;
        //myImage[3].sprite = Resources.Load("Images/UI/遊戲頭像/ALL_N", typeof(Sprite)) as Sprite;
    }
	
	// Update is called once per frame
	void Update () {
        if (ischangetest)
        {
            ExcuteAnime(ref whitchelftest);
            ischangetest = false;
        }
        
    }
    void ExcuteAnime(ref int whitchelf)
    {
        if (whitchelf == 1)
        {
            anim[0].SetTrigger(mychooseelf[0] + "tobig");
            anim[1].SetTrigger(mychooseelf[1] + "tosmall");
            whitchelf = 2;
            Debug.Log("1");
        }
        else if (whitchelf == 2)
        {
            anim[0].SetTrigger(mychooseelf[0] + "tosmall");
            anim[1].SetTrigger(mychooseelf[1] + "tobig");
            whitchelf = 1;
            Debug.Log("2");
        }
    }
}
