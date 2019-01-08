using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomScene : MonoBehaviour
{
    [SerializeField]
    private Fungus.Flowchart flowchart;
    [SerializeField]
    private GameObject target;
    
    AudioSource source;

    private void Start()
    {

        source = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        
        if (flowchart.GetBooleanVariable("isstoryCGend") == true)
        {
            target.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
