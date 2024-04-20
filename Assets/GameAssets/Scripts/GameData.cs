using UnityEngine;

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
}