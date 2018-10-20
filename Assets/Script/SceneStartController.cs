using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStartController : MonoBehaviour {

    public void OnStartBtn()
    {
        SceneManager.LoadScene("HomeMama");
    }
    public void OnExitBtn()
    {
        Application.Quit();
    }
}
