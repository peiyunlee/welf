using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTest : MonoBehaviour {
    public float timeBetweenAttacks = 2f;
    public int attackDamage = 1;

    GameObject player;
    HealthTest healthTest;
    bool playerInRange;
    float timer;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Enemy");
        healthTest = player.GetComponent<HealthTest>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
            //Debug.Log("attack.update");
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        timer = 0;

        if (healthTest.currentHealth > 0)
        {
            healthTest.TakeDamage(attackDamage);
            //Debug.Log("attack.attack");
        }
    }
}
