using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRender : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = ScharedData.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        EventManager.eventOnScoreUpdate += ChangeScoreText;
    }
    void OnDisable()
    {
        EventManager.eventOnScoreUpdate -= ChangeScoreText;
    }
    private void ChangeScoreText()
    {
        gameObject.GetComponent<Text>().text = (ScharedData.Score).ToString();
    }
    

}
