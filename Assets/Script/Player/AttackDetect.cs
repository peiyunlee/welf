using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetect : MonoBehaviour
{
    public bool isTouch;

    public HealthTest healthTest;
    public EnemyHealth enemyHealth;
    public middleEnemy_Health middleHealth;
    // Use this for initialization
    private void Awake()
    {
       // Debug.Log("adaw");
    }
    void Start()
    {
        isTouch = false;

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
        }

        if (other.CompareTag("main"))
        {
            isTouch = true;

            enemyHealth = other.GetComponent<EnemyHealth>();
        }

        if (other.CompareTag("middlemain"))
        {
            isTouch = true;

            middleHealth = other.GetComponent<middleEnemy_Health>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("EnemyTest"))
        {
            isTouch = false;

            healthTest = null;
        }
        if (other.CompareTag("main"))
        {
            isTouch = false;

            enemyHealth = null;
        }

        if (other.CompareTag("middlemain"))
        {
            isTouch = false;

            middleHealth = null;
        }
    }
}