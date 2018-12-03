using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTest : MonoBehaviour {
    public int startingHealth = 10;
    public int currentHealth;
    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
        Debug.Log("ht");
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
