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
    public int whitchelf;
    // Use this for initialization
    void Start () {
        anim[0]=gameobject[0].GetComponent<Animator>();
        anim[1] = gameobject[1].GetComponent<Animator>();
        mychooseelf[0] = GameManager.chooseelf[0];
        mychooseelf[1] = GameManager.chooseelf[1];
        myImage[0].sprite = Resources.Load("Images/UI/遊戲頭像/" + mychooseelf[0] + "_C", typeof(Sprite)) as Sprite;
        myImage[1].sprite = Resources.Load("Images/UI/遊戲頭像/" + mychooseelf[1] + "_H", typeof(Sprite)) as Sprite;
        myImage[2].sprite = Resources.Load("Images/UI/遊戲頭像/" + mychooseelf[0] + "_CS", typeof(Sprite)) as Sprite;
        myImage[3].sprite = Resources.Load("Images/UI/遊戲頭像/ALL_N", typeof(Sprite)) as Sprite;
    }
	
	// Update is called once per frame
	void Update () {
        if (whitchelf == 1)
        {
            anim[0].SetTrigger("");
        }
	}
}
