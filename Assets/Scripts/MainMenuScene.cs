using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Stage1() {
        SceneManager.LoadScene("Stage 0.5");
    }

    public void Stage2() {
        SceneManager.LoadScene("Stage 1.5");
    }

    public void Credit() {
        SceneManager.LoadScene("Credit");
    }

    public void Exit() {
        Application.Quit();
    }
}
