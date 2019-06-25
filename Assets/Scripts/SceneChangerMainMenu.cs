﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerMainMenu : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (SceneManager.GetActiveScene().name.Equals("Main Menu")) {
                Exit();
            } else if (SceneManager.GetActiveScene().name.Equals("Credit")) {
                MainMenu();
            }
        }
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
        Debug.Log("Quit");
        Application.Quit();
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}