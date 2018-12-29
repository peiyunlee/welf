using UnityEngine;
using System.Collections;
using Fungus;

public class CameraFollow : MonoBehaviour {

    // 這個程式會附加到撥放器main Camera內，這裡死區deadZone設置為0，可以在unity內調到想要的效果
    [SerializeField]
    private Flowchart flowchart;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    public float addy;
    [SerializeField]
    public float miny;
    [SerializeField]
    public float jumphigh;
    [SerializeField]
    private float maxvector;
    [SerializeField]
    private float minvector;
    [SerializeField]
    private float maxy;
    bool camerastop;
    void Start () {
        target = GameObject.Find("Player");
    }
	
	void Update () {
        camerastop = flowchart.GetBooleanVariable("camerastop");
        if (GameManager.DestroyGameManager == true)
        {
            target = GameObject.FindWithTag("Player");
            GameManager.DestroyGameManager = false;
        }
        if (target.transform.position.x < minvector)
        {
            if (target.transform.position.y < jumphigh)
            {
                transform.position = new Vector3(minvector, miny, transform.position.z);
            }
            else if(target.transform.position.y > maxy)
            {
                transform.position = new Vector3(minvector, maxy + addy, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(minvector, target.transform.position.y + addy, transform.position.z);
            }
        }
        else if (target.transform.position.x > maxvector)
        {
            if (target.transform.position.y < jumphigh)
            {
                transform.position = new Vector3(maxvector, miny, transform.position.z);
            }
            else if (target.transform.position.y > maxy)
            {
                transform.position = new Vector3(maxvector, maxy + addy, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(maxvector, target.transform.position.y + addy, transform.position.z);
            }
        
    }
        else
        {
            if (target.transform.position.y < jumphigh)
            {
                if (camerastop != true)
                    transform.position = new Vector3(target.transform.position.x, miny, transform.position.z);
                
            }
            else if (target.transform.position.y > maxy)
            {
                transform.position = new Vector3(target.transform.position.x, maxy + addy, transform.position.z);
            }
            else
            { 
                transform.position = new Vector3(target.transform.position.x, target.transform.position.y+addy, transform.position.z);
            }
        }
	}
}
