
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameDataScriptableObject gameDataValues;
    public TextMeshProUGUI tmpScoreText;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameDataValues.tmpScore = 0;
        gameDataValues.score = 0;
        gameDataValues.isWorking = false;
    }

    // Update is called once per frame
    void Update()
    {
        tmpScoreText.text = "Score carrying: " + gameDataValues.tmpScore.ToString();
        scoreText.text = "Score: " + gameDataValues.score.ToString();
    }

    void FixedUpdate()
    {
    }
}
