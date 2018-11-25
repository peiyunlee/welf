using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    static GameManager instance;
    [SerializeField]
    public static int[] chooseelf = new int[2];
    void Awake()
    {
        if (instance == null)   //當第一個GameManager出現不要destroy
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance)  //當第二個GameManager出現刪除
        {
            Destroy(gameObject);
        }
    }
}