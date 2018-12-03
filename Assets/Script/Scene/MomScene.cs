using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomScene : MonoBehaviour
{
    [SerializeField]
    private Fungus.Flowchart flowchart;
    [SerializeField]
    private GameObject target;
    void Update()
    {
        if (flowchart.GetBooleanVariable("isstoryCGend") == true)
        {
            target.GetComponent<BoxCollider2D>().isTrigger = true;
            Debug.Log(target.GetComponent<BoxCollider2D>().isTrigger);
        }
    }
}
