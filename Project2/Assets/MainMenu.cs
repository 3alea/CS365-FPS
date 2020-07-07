using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        //When building it, it closes down the program
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Tutorial(){
        //When building it, it closes down the program
        SceneManager.LoadScene("Tutorial");
    }
}
