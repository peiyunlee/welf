using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetect : MonoBehaviour {
    public bool isTouch;

    public HealthTest healthTest;
    // Use this for initialization
    private void Awake()
    {
        Debug.Log("adaw");
    }
    void Start () {
        isTouch = false;      
        healthTest = GetComponent<HealthTest>();
        Debug.Log("adst");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("EnemyTest"))
        //{
        //    isTouch = true;
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("EnemyTest"))
        //{
        //    isTouch = false;
        //}
    }
}
