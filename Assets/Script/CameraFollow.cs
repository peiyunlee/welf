using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    // 這個程式會附加到撥放器main Camera內，這裡死區deadZone設置為0，可以在unity內調到想要的效果
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
    void Start () {
    }
	
	void Update () {


        if (target.transform.position.x < minvector)
        {
            if (target.transform.position.y < jumphigh)
            {
                transform.position = new Vector3(minvector, miny, transform.position.z);
                Debug.Log("a");
            }
            else
            {
                transform.position = new Vector3(minvector, target.transform.position.y + addy, transform.position.z);
                Debug.Log("b");
            }
        }
        else if (target.transform.position.x > maxvector)
        {
            if (target.transform.position.y < jumphigh)
            {
                transform.position = new Vector3(maxvector, miny, transform.position.z);
                Debug.Log("c");
            }
            else
            {
                transform.position = new Vector3(maxvector, target.transform.position.y + addy, transform.position.z);
                Debug.Log("d");
            }
        
    }
        else
        {
            if (target.transform.position.y < jumphigh)
            {
                transform.position = new Vector3(target.transform.position.x, miny, transform.position.z);
                Debug.Log("e");
            }
            else
            { 
                transform.position = new Vector3(target.transform.position.x, target.transform.position.y+addy, transform.position.z);
                Debug.Log("f");
            }
        }
	}
}
