using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Initialize : MonoBehaviour {
    [SerializeField]
    private UnityEvent onStart;
	// Use this for initialization
	void Start () {
        this.onStart.Invoke();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
