using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeartDisappear : MonoBehaviour {
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void AnimControl()
    {
        anim.SetTrigger("Disappear");
        Debug.Log("5");
    }

}
