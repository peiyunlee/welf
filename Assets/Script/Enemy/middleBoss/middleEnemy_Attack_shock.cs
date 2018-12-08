using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleEnemy_Attack_shock : MonoBehaviour {

    Rigidbody2D playerRigidbody;
    public Transform main;//要跟随英雄






    private void normalAttack_hit()
    {


        if (((transform.position.x - initialposition) > 20))
        {

            Vector2 transformValue = new Vector2(0, 0);
            playerRigidbody.velocity = transformValue;
            //Debug.Log("pause");
            System.Threading.Thread.Sleep(500);
            transform.Translate(new Vector2(initialposition, 0) * 1f);
        }
        else
        {

            transform.Translate(new Vector2(5, 0) * 0.5f);

        }



    }

    private float initialposition;
    private void Start()
    {
        initialposition = transform.position.x;
        playerRigidbody = GetComponent<Rigidbody2D>();
        Transform target = GameObject.FindGameObjectWithTag("main").transform;

    }


    private void Update()
    {

        normalAttack_hit();




    }

}
