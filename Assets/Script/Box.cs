using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public GameObject gameobject;
    public UIHeart uiheart;
    private void Start()
    {
        gameobject = GameObject.Find("LifeIndicator");
        uiheart = gameobject.GetComponent<UIHeart>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (uiheart.testcurrentHealth < 20)
        {
            uiheart.AddLife(uiheart.testcurrentHealth);
        }
            
    }
}
