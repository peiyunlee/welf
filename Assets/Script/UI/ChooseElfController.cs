using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Fungus;

public class ChooseElfController : MonoBehaviour
{
    //public GameObject GameManager;
    [SerializeField]
    private int ELFCANCOUNT;
    [SerializeField]
    private GameObject textgameobject;
    [SerializeField]
    private Text choosetext;
    [SerializeField]
    private GameObject okbtn;
    [SerializeField]
    bool[] isbeingchoosed = new bool[3];  //水精靈已被選擇
    [SerializeField]
    int count = 0;
    public GameObject welf;
    public Toggle toggle;
    public Flowchart flowchart;
    public int itime = 0;

    public VillageTwo villagetwo;
    //private int scenenumber;

    enum ELF
    {
        Nochoose=0,
        Vigorous,
        Acute,
        Tender,
    }
    // Use this for initialization
    void Start () {
        okbtn = GameObject.Find("OKBtn");
        okbtn.SetActive(false);
        textgameobject = GameObject.Find("Choosetext");
        choosetext = textgameobject.GetComponent<Text>();
        villagetwo= GameObject.Find("VillageTwo").GetComponent<VillageTwo>();
        choosetext.text = "請選擇" + ELFCANCOUNT + "隻水精靈";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnElfBtnClick(int elfnumber)  //當任一按鈕被按下傳送該按鈕號碼
    {
        if (isbeingchoosed[elfnumber-1]&&count<= ELFCANCOUNT)  //已被選擇過且沒滿或滿了
        {
            count--;
            isbeingchoosed[elfnumber-1] = false;
            for (int i = 0; i < ELFCANCOUNT; i++)
            {
                if (GameManager.chooseelf[i] == elfnumber) GameManager.chooseelf[i] = 0;
            }
            //取消選擇
        }
        else if (!isbeingchoosed[elfnumber-1] && count < ELFCANCOUNT) //還沒被選擇過且沒滿
        {
            count++;
            isbeingchoosed[elfnumber-1] = true;
            GameManager.chooseelf[count - 1] = elfnumber;
            //選擇
        }
        if (count== ELFCANCOUNT)
        {
            
            textgameobject.SetActive(false);
            okbtn.SetActive(true);
            switch (isbeingchoosed[0])
            {
                case true:
                    switch (isbeingchoosed[1])
                    {
                        case true:
                            welf = GameObject.Find("TenderToggle");
                            toggle =welf.GetComponent<Toggle>();
                            toggle.interactable = false;
                            break;
                        case false:
                            welf = GameObject.Find("AcuteToggle");
                            toggle = welf.GetComponent<Toggle>();
                            toggle.interactable = false;
                            break;
                    }
                    break;
                case false:
                    welf = GameObject.Find("VigorousToggle");
                    toggle = welf.GetComponent<Toggle>();
                    toggle.interactable = false;
                    break;
            }
        }
        else if(count< ELFCANCOUNT)
        {

            textgameobject.SetActive(true);
            okbtn.SetActive(false);
            welf = GameObject.Find("VigorousToggle");
            toggle = welf.GetComponent<Toggle>();
            toggle.interactable = true;
            welf = GameObject.Find("AcuteToggle");
            toggle = welf.GetComponent<Toggle>();
            toggle.interactable = true;
            welf = GameObject.Find("TenderToggle");
            toggle = welf.GetComponent<Toggle>();
            toggle.interactable = true;
        }
    }
    public void OnOKBtnClick()
    {
        if (itime == 1)
        {
            Fungus.Flowchart.BroadcastFungusMessage("skillteach2");
            villagetwo.Welfdisappear();
        }
        else if (itime == 2)
            AllSceneController.tonextscene = true;
    }

    //public void OnBackBtnClick()
    //{
    //    count = 0;
    //    for (int i = 0; i < 3; i++)
    //    {
    //        isbeingchoosed[i] = false;//重置所有選擇
    //        if(i<2) GameManager.chooseelf[i] = 0;
    //        //取消所有選擇
    //    }
       
    //}
}
