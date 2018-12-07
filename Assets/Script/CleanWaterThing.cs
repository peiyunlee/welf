using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanWaterThing : MonoBehaviour
{
    public GameObject gameobject;
    public CleanWater cleanwater;
    private void Start()
    {
        gameobject = GameObject.Find("CleanWater");
        cleanwater = gameobject.GetComponent<CleanWater>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cleanwater.AddCleanWater();
        Debug.Log("aa");
    }
}
