using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAttack : PlayerAttack {
    public bool enemyDetecter = false;

    GameObject enemy;
    public HealthTest healthTest;
    // Use this for initialization
    void Start () {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        Debug.Log("sa");
        healthTest = GetComponent<HealthTest>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetHurt(Attack playerAttack)
    {
        Debug.Log("1");
            switch (playerAttack)
            {          
                case Attack.idle:
                    healthTest.TakeDamage(0);
                    break;
                case Attack.normal:
                    healthTest.TakeDamage(1);
                    break;
                case Attack.skill:
                    healthTest.TakeDamage(2);
                    break;
            }
               
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == enemy)
        {
            enemyDetecter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == enemy)
        {
            enemyDetecter = false;
        }
    }
}
