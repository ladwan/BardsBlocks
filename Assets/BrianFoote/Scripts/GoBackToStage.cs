
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToStage : MonoBehaviour {
    public int Scenetoload;

    public void GoBack()
    {
        SceneManager.LoadScene(Scenetoload);
    }
}
