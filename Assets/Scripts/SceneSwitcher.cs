using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {
    //public static SceneSwitcher instance;
    public float timer = 0;
    float currentTime = 0;
    public int targetScene;

    public static int currentScene;
    //void Awake() {
    //    if (instance == null)
    //        instance = this;
    //}

    public void A_ExitButton() {
        Application.Quit();
    }

    public void A_LoadScene(int i) {
        currentScene = i;
        SceneManager.LoadScene(i);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            A_ExitButton();

		if (timer > 0) {
            currentTime += Time.deltaTime;

			if (timer <= currentTime) {
                A_LoadScene(targetScene);
			}

			if (Input.GetMouseButtonDown(0)) {
                A_LoadScene(targetScene);
            }
		}

    }
}
