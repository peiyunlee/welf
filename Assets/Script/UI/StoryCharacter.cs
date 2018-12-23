using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryCharacter : MonoBehaviour {
    public GameObject[] story;
    public Image[] image;
    private int currentstorynumber;
	// Use this for initialization
	void Start () {
        currentstorynumber = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnCharacterBtnClick(int stroynumber)
    {
        story[currentstorynumber - 1].SetActive(false);
        story[stroynumber - 1].SetActive(true);
        image[currentstorynumber - 1].sprite = Resources.Load("Images/UI/StoryMenu/" + currentstorynumber + "_N", typeof(Sprite)) as Sprite;
        image[stroynumber - 1].sprite = Resources.Load("Images/UI/StoryMenu/" + stroynumber + "_H", typeof(Sprite)) as Sprite;
        currentstorynumber = stroynumber;
    }
}
