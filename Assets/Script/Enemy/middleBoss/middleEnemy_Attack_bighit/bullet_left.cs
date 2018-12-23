using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_left : MonoBehaviour {
    
    public float speed;//子彈的速度
    public Transform enemy1;
    float attackRange = 40f;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
       /* Debug.Log(enemy1.position.x - transform.position.x);*/
        

        if ((float)(enemy1.position.x-transform.position.x) > attackRange)
        {
            
          
            Destroy(this.gameObject);

        }
    }
}
