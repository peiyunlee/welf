using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanWaterThing : CleanWater
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddCleanWater();
    }
}
