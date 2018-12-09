using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_right: MonoBehaviour {
    public float speed ;//子彈的速度
    public Transform enemy1;
     float attackRange = 100f;
    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if ((transform.position.x - enemy1.position.x) > attackRange)
        {
           Debug.Log("destroy");
            Destroy(this.gameObject);

        }
    }
}
