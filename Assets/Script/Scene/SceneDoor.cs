using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDoor : MonoBehaviour {
    [SerializeField]
    private GameObject[] Turn;
    [SerializeField]
    Animator anim0;
    [SerializeField]
    Animator anim1;
    // Use this for initialization
    private void Awake()
    {

        Turn[0] = GameObject.Find("UpImage");
        Turn[1] = GameObject.Find("DownImage");
        anim0 = Turn[0].GetComponent<Animator>();
        anim1 = Turn[1].GetComponent<Animator>();
    }
    void Start()
    {
        anim1.SetTrigger("Isdown");
        anim0.SetTrigger("Isup");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        anim0.SetTrigger("Isdown");
        anim1.SetTrigger("Isup");
        if (this.name == "NextSceneDoor")
        {
            Invoke("Tonextscene", 1.0f);
            
        }
        else if (this.name == "PreSceneDoor")
        {
            Invoke("Toprescene", 1.0f);
        }
    }
    void Tonextscene()
    {
        AllSceneController.tonextscene = true;
    }
    void Toprescene()
    {
        AllSceneController.toprescene = true;
    }
}
