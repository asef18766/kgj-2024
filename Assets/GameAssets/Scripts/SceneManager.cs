using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // HACK: set ref in editor
    public GameObject credits;
    public GameObject how2play;

    //switch between scenes
    public void ChangeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    // switch to intro scene
    public void IntroScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
    }

    // switch to game scene
    public void GameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        SoundManager.instance.ChangeMusic(6);
    }

    // HACK: menu buttons
    public void OpenCredits()
    {
        this.credits.SetActive(true);
    }

    public void OpenHowToPlay()
    {
        this.how2play.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
