using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSet : MonoBehaviour {
    public float skillTime = 5;
    public float timer = 0;
    public int hurt = 2;

    public bool isSkill = false;

    public bool keySkill;
    public float keyHorizontal;

    
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    //public void GetKey()
    //{
    //    keySkill = Input.GetButtonDown("Skill");

    //    keyHorizontal = Input.GetAxisRaw("Horizontal");
    //}
}
