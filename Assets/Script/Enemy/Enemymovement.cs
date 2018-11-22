using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Enemymovement : MonoBehaviour {
    public Transform main;

    private float moveSpeed = 5.0f;

    private float rotateSpeed = 5.0f;

    private Transform mytransform;//自己
    Transform target = GameObject.FindGameObjectWithTag("main").transform;



    void Awake()
    {
        Transform target = GameObject.FindGameObjectWithTag("main").transform;

    }


    void Update()
    {
        Debug.DrawLine(target.transform.position, this.transform.position, Color.yellow);


        mytransform.rotation = Quaternion.Slerp(mytransform.rotation, Quaternion.LookRotation(target.position - mytransform.position), rotateSpeed * Time.deltaTime);


        mytransform.position += mytransform.forward * moveSpeed * Time.deltaTime;




    }
}
