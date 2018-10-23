using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour {
    public Transform Player;
    private UnityEngine.AI.NavMeshAgent nav;


    void Awake()
    {
        Player =GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {

        nav.SetDestination(Player.position);
        
        



    }
}
