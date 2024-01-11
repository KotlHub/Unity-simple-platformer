using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float currentTime = 0f;
    private int score = 0;
    private TextMeshProUGUI text;
    private void Start()
    {
        text = GameObject.Find("ScoreValue").GetComponent<TextMeshProUGUI>();
        text.text = "Score: " + score.ToString();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > 1f)
        {
            score++;
            text.text = "Score: " + score.ToString();
            currentTime = 0f;
        }
    }
}
