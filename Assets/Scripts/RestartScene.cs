using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    private string previousScene;

    // Start is called before the first frame update
    void Start()
    {
        previousScene = "Main Menu";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PreviousScene(string scene) {
        previousScene = scene;
    }

    public string GetPreviousScene() {
        return previousScene;
    }

    public void Restart() {
        previousScene = PlayerPrefs.GetString("retryScene");
        SceneManager.LoadScene(previousScene);
    }
}
