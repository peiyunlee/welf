using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetect : MonoBehaviour
{
    public bool isTouch;

    public HealthTest healthTest;
    public EnemyHealth enemyHealth;
    public middleEnemy_Health middleHealth;
    public littleEnemy2_health littleEnemy;


    public bool[] health;
    
    // Use this for initialization
    private void Awake()
    {
        // Debug.Log("adaw");

        health = new bool[4];
    }
    void Start()
    {
        isTouch = false;

        for (int i = 0; i < 4; i++)
        {
            health[i] = false;
        }
        //health = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("EnemyTest"))
        {
            isTouch = true;

            healthTest = other.GetComponent<HealthTest>();

            health[0] = true;
        }

        if (other.CompareTag("main"))
        {
            isTouch = true;

            enemyHealth = other.GetComponent<EnemyHealth>();

            health[1] = true;
        }

        if (other.CompareTag("middlemain"))
        {
            isTouch = true;

            middleHealth = other.GetComponent<middleEnemy_Health>();

            health[2] = true;
        }

        if (other.CompareTag("main2"))
        {
            isTouch = true;

            littleEnemy = other.GetComponent<littleEnemy2_health>();

            health[3] = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("EnemyTest"))
        {
            isTouch = false;

            healthTest = null;

            health[0] = false;
        }
        if (other.CompareTag("main"))
        {
            isTouch = false;

            enemyHealth = null;

            health[1] = false;
        }

        if (other.CompareTag("middlemain"))
        {
            isTouch = false;

            middleHealth = null;

            health[2] = false;
        }
        if (other.CompareTag("main2"))
        {
            isTouch = false;

            littleEnemy = null;

            health[3] = false;
        }
    }
}