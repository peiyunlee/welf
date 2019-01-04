using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private GameObject lifeIndicator;
    private UIHeart uiheart;
    //血量
    public int startingHealth = 20;
    public static int currentHealth;

    //條件判斷
    public static bool isProtect = false;
    public bool isDamaged = false;
    public bool isDead = false;

    PlayerMovement playerMovement;
    Animator playerAnim;
    // Use this for initialization
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnim = GetComponent<Animator>();

        if (AllSceneController.iscenenumber >= 6)
        {
            lifeIndicator = GameObject.FindWithTag("lifeIndicator");
            uiheart = lifeIndicator.GetComponent<UIHeart>();
        }

        startingHealth = GameManager.playercurrenthealth;
        //startingHealth = 20;
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        isDamaged = false;
        //Debug.Log("health.update");
        Animating();

        PlayerMovement.canMove = true;
    }

    public void TakeDamage(int amount)
    {
        if (!isProtect)
        {
            isDamaged = true;

            PlayerMovement.canMove = false;

            currentHealth -= amount;

            playerAnim.SetTrigger("isDamaged");

            uiheart.DecreaseLife(currentHealth);
            //Debug.Log("health.take");
            Debug.Log("player" + currentHealth);

            //PlayerAttack.attackCount = 0;
            //isDamaged = false;
            if (currentHealth <= 0 && !isDead)
            {
                Death();
            }
        }
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
