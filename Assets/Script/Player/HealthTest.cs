using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTest : MonoBehaviour {
    public int startingHealth = 5;
    public int currentHealth;
    // Use this for initialization
    void Start () {
        Debug.Log("htst");
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        //Debug.Log("health.take");
        Debug.Log(currentHealth);

        }
    }

