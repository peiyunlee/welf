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
    private void Update()
    {
        if (testbool)
        {
            AttackBox();
            testbool = false;
        }
    }
    private void AttackBox()
    {
        count++;
        if (count == 1)
        {
            BoxHurt();
        }
        else if (count == 2)
        {
            BoxDestroy();
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
        m_Animator.SetTrigger("Destroy");
    }
    void EatHeart()
    {
        currenthealth = PlayerHealth.currentHealth;
        if (currenthealth < 20)
        {
            for (int i = 0; i < 20- currenthealth&&i<4; i++)
            {
                uiheart.AddLife(currenthealth+i);
            }
                
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (count == 2)
        {
            EatHeart();
        }
    }
}
