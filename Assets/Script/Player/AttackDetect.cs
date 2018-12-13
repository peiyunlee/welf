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
        
        Debug.Log("adst");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("EnemyTest"))
        {
            isTouch = true;

            healthTest = other.GetComponent<HealthTest>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("EnemyTest"))
        {
            isTouch = false;

            healthTest = null;
        }
    }
}
