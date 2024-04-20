
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameDataScriptableObject gameDataValues;
    public GameObject player;
    public TextMeshProUGUI tmpScoreText;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameDataValues.tmpScore = 0;
        gameDataValues.score = 0;
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
