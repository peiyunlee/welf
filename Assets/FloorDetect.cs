using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetect : MonoBehaviour {
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {
            if (gameObject.name == "one")
            {
                Enemymovement.idle_speed *= -1f;
            }
            else if(gameObject.name == "two")
            {
                littleEnemy2_movement.idle_speed *= -1f;
            }

        }
    }
}
