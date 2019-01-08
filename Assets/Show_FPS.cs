using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Show_FPS : MonoBehaviour
{
    public Text fpsText;
    float deltaTime;
    private void Start()
    {
        fpsText = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        deltaTime += (Time.deltaTime-deltaTime) *0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();
    }
}
