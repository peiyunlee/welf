using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftBulletController : MonoBehaviour {
    public float rate = 3; //發子彈的速率
    public GameObject bullet;//取得子彈的gameobject
    private int bullet_time = 0;
    float timer;
    // Use this for initialization
    void Start () {

        fire();


    }
   
	
	public void fire()
    {
        GameObject.Instantiate(bullet,transform.position,Quaternion.identity);//複製子彈
      
    }
    

    
}
