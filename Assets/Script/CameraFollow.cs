using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
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
            maxvector.y = player.transform.position.y + 1.5f * addvector.y;
            transform.position = maxvector;
        }
        else if (transform.position.x <= minvector.x)
        {
            minvector.y = player.transform.position.y + 1.5f * addvector.y;
            transform.position = minvector;
        }
        else
        {
            transform.position = player.transform.position + offset;
        }
         //Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.       
    }
}
