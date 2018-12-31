using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public bool testbool;
    public GameObject gameobject;
    public UIHeart uiheart;
    public int currenthealth;
    public int count;
    Animator m_Animator;
    private void Start()
    {
        gameobject = GameObject.Find("LifeIndicator");
        uiheart = gameobject.GetComponent<UIHeart>();
        m_Animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (/*collision.tag=="Player"*/testbool)
        {
            count++;
            if (count == 1)
            {
                BoxHurt();
            }
            else if(count == 2)
            {
                BoxDestroy();
            }
            
        }
        else if (count >= 2)
        {
            EatHeart();
        }
    }
    void BoxHurt()
    {
        m_Animator.SetTrigger("Boxhurt");
    }
    void BoxDestroy()
    {
        m_Animator.SetTrigger("Boxhurt");
    }
    void EatHeart()
    {
        currenthealth = PlayerHealth.currentHealth;
        if (currenthealth < 20)
        {
            uiheart.AddLife(currenthealth);
            Destroy(this);
        }
    }
}
