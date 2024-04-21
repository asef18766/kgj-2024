using UnityEngine;
using GameAssets.Scripts.QTE;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameDataScriptableObject", order = 1)]
public class GameDataScriptableObject : ScriptableObject
{

    public int score;
    public int tmpScore;
    public int speed;
    public bool isWorking;
    public float employeeUpTime;
    public float employeeCooldown;
    public bool isConfused;
    public int originalScoreIncrease;
    public int scoreIncrease;
    public float scoreMultiplier;
    public int btnCnt;
    public ManagerData managerData;

    public void reset() {
        score = 0;
        isWorking = false;
        isConfused = false;
        catchedReset();
    }

    public void catchedReset() {
        tmpScore = 0;
        scoreIncrease = originalScoreIncrease;
        managerData.speed = managerData.originalSpeed;
        var qteController = FindObjectOfType<QTEController>(true);
        qteController.BtnCnt = btnCnt;
    }
}