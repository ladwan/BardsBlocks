using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneREF  {
    public static int CurrentScene;

	// Use this for initialization

      public static int SetCurrentScene
    {
        set
        {
            CurrentScene = SceneManager.GetActiveScene().buildIndex;
        }
    }

}
