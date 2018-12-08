using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_left : MonoBehaviour {
    public float speed;//子彈的速度
    public Transform enemy1;
    public float attackRange = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if ((enemy1.position.x-transform.position.x) > attackRange)
        {

            Destroy(this.gameObject);

        }
    }
}
