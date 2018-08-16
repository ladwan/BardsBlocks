using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour {

    public Scene Stage;

    public void StageSelect()
    {
        SceneManager.LoadScene("StageSelect", LoadSceneMode.Single);
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

    public void Help()
    {
        SceneManager.LoadScene("Help", LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TheStage(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
