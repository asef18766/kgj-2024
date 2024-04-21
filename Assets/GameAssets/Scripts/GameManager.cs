
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using GameAssets.Scripts.QTE;
public class GameManager : MonoBehaviour
{
    public GameDataScriptableObject gameDataValues;

    public ManagerData managerData;
    private UIController uiController;
    private int prevScore;

    void Start()
    {
        this.gameDataValues.reset();
        this.uiController = FindObjectOfType<UIController>();
        this.prevScore = this.gameDataValues.score;
    }

    void Update()
    {
        this.uiController.SetCarryingScore(this.gameDataValues.tmpScore);
        if (this.gameDataValues.score != this.prevScore)
        {
            this.uiController.AddValueToSlider(this.gameDataValues.score - this.prevScore);
        }
        this.prevScore = this.gameDataValues.score;
    }
}
