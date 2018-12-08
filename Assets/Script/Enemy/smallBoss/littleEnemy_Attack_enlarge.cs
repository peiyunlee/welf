using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class littleEnemy_Attack_enlarge : MonoBehaviour {
    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄

    void normalAttack_enlarge()
    {

        transform.localScale = new Vector2(1.5f, 1.5f);//更改為1.5倍

    }
    void normalAttack_shrink()
    {

        transform.localScale = new Vector2(1f, 1f);//更改為1.5倍

    }

    // Use this for initialization
    void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Transform target = GameObject.FindGameObjectWithTag("main").transform;
    }

    // Update is called once per frame
    float timer;
	void Update () {
        timer += Time.deltaTime;

        if (((timer%5)>1)&& ((timer % 5) < 3)) {

            normalAttack_enlarge();

        }

        else if(((timer % 5) > 3) && ((timer % 5) < 5)) {
            normalAttack_shrink();
        }
    }
}
