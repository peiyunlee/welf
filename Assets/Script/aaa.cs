using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour {
    public GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    [SerializeField]
    private Vector3 addvector;
    [SerializeField]
    private Vector3 maxvector;
    [SerializeField]
    private Vector3 minvector;
    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position+ addvector;
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        if (transform.position.x >= maxvector.x)
        {
            //maxvector.y = player.transform.position.y;
            transform.position = maxvector;
            Debug.Log("maxvector");
        }
        else if (transform.position.x <= minvector.x)
        {
            //minvector.y = player.transform.position.y;
            transform.position = minvector;
            Debug.Log("minvector");
        }
        else
        {
            transform.position = player.transform.position + offset;
            Debug.Log("NORMAL");
        }
    }
}
