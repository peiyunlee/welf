using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_left : MonoBehaviour {
    PlayerHealth playerhealth;
    public float speed;//子彈的速度
    public Transform enemy1;
    float attackRange = 80f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            playerhealth.TakeDamage(1);

        }
    }
    void Start()
    {

        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
      
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 20f * Time.deltaTime);
       /* Debug.Log(enemy1.position.x - transform.position.x);*/
        

        if ((float)(enemy1.position.x-transform.position.x) > attackRange)
        {
            
          
            Destroy(this.gameObject);

        }
    }
}
