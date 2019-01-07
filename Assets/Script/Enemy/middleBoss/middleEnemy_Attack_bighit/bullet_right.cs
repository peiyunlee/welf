using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_right: MonoBehaviour {
    public float speed ;//子彈的速度
    public Transform enemy1;
    PlayerHealth playerhealth;
     float attackRange = 40f;
    // Update is called once per frame
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
        enemy1 = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }
    void Update () {
        transform.Translate(Vector3.right * 20 * Time.deltaTime);
        if (Vector2.Distance(enemy1.position, transform.position) > attackRange)
        {
           
            Destroy(this.gameObject);

        }
    }
}
