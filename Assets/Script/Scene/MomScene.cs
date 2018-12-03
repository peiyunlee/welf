using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomScene : MonoBehaviour {
    [SerializeField]
    private Fungus.Flowchart flowchart;
    void Update()
    {
        if (flowchart.GetBooleanVariable("isstoryCGend") == true)
        {
            AllSceneController.tonextscene = true;
        }
    }
}
