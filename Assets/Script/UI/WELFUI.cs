using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WELFUI : MonoBehaviour {
    [SerializeField]
    Image [] myImage;
    [SerializeField]
    private int [] mychooseelf;
    // Use this for initialization
    void Start () {
        mychooseelf[0] = GameManager.chooseelf[0];
        mychooseelf[1] = GameManager.chooseelf[1];
        myImage[0].sprite = Resources.Load("Images/UI/遊戲頭像/" + mychooseelf[0] + "_C", typeof(Sprite)) as Sprite;
        myImage[1].sprite = Resources.Load("Images/UI/遊戲頭像/" + mychooseelf[1] + "_H", typeof(Sprite)) as Sprite;
        myImage[2].sprite = Resources.Load("Images/UI/遊戲頭像/" + mychooseelf[0] + "_CS", typeof(Sprite)) as Sprite;
        myImage[3].sprite = Resources.Load("Images/UI/遊戲頭像/ALL_N", typeof(Sprite)) as Sprite;
        //switch (mychooseelf[0])
        //{
        //    case 1:
        //        myImage[0].sprite = Resources.Load("Images/UI/遊戲頭像/"+ mychooseelf[0] + "_C", typeof(Sprite)) as Sprite;
        //        switch (mychooseelf[1])
        //        {
        //            case 2:
        //                myImage[1].sprite = Resources.Load("Images/UI/遊戲頭像/急性子_C", typeof(Sprite)) as Sprite;
        //                break;
        //            case 3:
        //                myImage[1].sprite = Resources.Load("Images/UI/遊戲頭像/溫柔_C", typeof(Sprite)) as Sprite;
        //                break;
        //        }
        //        break;
        //    case 2:
        //        myImage[0].sprite = Resources.Load("Images/UI/遊戲頭像/急性子_C", typeof(Sprite)) as Sprite;
        //        switch (mychooseelf[1])
        //        {
        //            case 1:
        //                myImage[1].sprite = Resources.Load("Images/UI/遊戲頭像/大力_C", typeof(Sprite)) as Sprite;
        //                break;
        //            case 3:
        //                myImage[1].sprite = Resources.Load("Images/UI/遊戲頭像/溫柔_C", typeof(Sprite)) as Sprite;
        //                break;
        //        }
        //        break;
        //    case 3:
        //        myImage[0].sprite = Resources.Load("Images/UI/遊戲頭像/溫柔_C", typeof(Sprite)) as Sprite;
        //        switch (mychooseelf[1])
        //        {
        //            case 2:
        //                myImage[1].sprite = Resources.Load("Images/UI/遊戲頭像/急性子_C", typeof(Sprite)) as Sprite;
        //                break;
        //            case 1:
        //                myImage[1].sprite = Resources.Load("Images/UI/遊戲頭像/大力_C", typeof(Sprite)) as Sprite;
        //                break;
        //        }
        //        break;
        //}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
