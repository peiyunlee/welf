using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    //血量
    public int startingHealth = 12;
    public int currentHealth;

    //條件判斷
    public bool isDamaged;
    public bool isDead;

    PlayerMovement playerMovement;
    Animator playerAnim;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnim = GetComponent<Animator>();

        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {       
        isDamaged = false;
       // Debug.Log(isDamaged);
    }

    void FixedUpdate()
    {
       Animating();
    }

    //被攻擊
    public void TakeDamage(int amount)
    {
        isDamaged = true;

        currentHealth -= amount;

        playerAnim.SetBool("IsDamage", isDamaged);

        Debug.Log(currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        playerMovement.enabled = false;

        Debug.Log("You Die!");
    }

    void Animating()
    {

        playerAnim.SetBool("IsDamage", isDamaged);

        playerAnim.SetBool("IsDead", isDead);
    }
}
