using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_left : MonoBehaviour {
    PlayerHealth playerhealth;
    public float speed;//子彈的速度
    public Transform enemy1;
    float attackRange = 40f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            playerhealth.TakeDamage(1);

        }
    }
    void Start()
    {

        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        enemy1 = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 20f * Time.deltaTime);
       
        if (Vector2.Distance(enemy1.position , transform.position)> attackRange)
        {
            
          
            Destroy(this.gameObject);

        }
    }
}
