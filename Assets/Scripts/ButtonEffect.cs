using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonEffect : MonoBehaviour {
    public string sceneToLoad;
    public bool Exit = false;
    // Use this for initialization
    public void LoadTheScene()
    {
        if (Exit)
        {
            Application.Quit();
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
