using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //血量
    public int startingHealth = 20;
    public int currentHealth;

    //條件判斷
    public bool isDamaged;
    public bool isDead;

    testplayermove playerMovement;
    Animator playerAnim;
    // Use this for initialization
    void Start()
    {
        playerMovement = GetComponent<testplayermove>();
        playerAnim = GetComponent<Animator>();

        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        isDamaged = false;
        //Debug.Log("health.update");
        Animating();
    }

    public void TakeDamage(int amount)
    {
        isDamaged = true;

        currentHealth -= amount;

        playerAnim.SetTrigger("isDamaged");

        //Debug.Log("health.take");
        Debug.Log(currentHealth);

        //isDamaged = false;
        //if (currentHealth <= 0 && !isDead)
        //{
        //    Death();
        //}
    }

    void Death()
    {
        isDead = true;

        playerAnim.SetTrigger("isDead");

        playerMovement.enabled = false;

        Debug.Log("You Die!");
    }

    void Animating()
    {
        //playerAnim.SetBool("isDamaged", isDamaged);
        //Debug.Log("health.anim");
    }
}
