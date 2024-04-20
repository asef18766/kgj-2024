using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //switch between scenes
    public void ChangeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    //swtitch to intro scene
    public void IntroScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
    }

    //swtitch to game scene
    public void GameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
