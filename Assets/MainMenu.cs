using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public static bool newGame = true;

    public void PlayNewGame()
    {
        newGame = true;
        SceneManager.LoadScene(1);
    }

    public void PlayGame()
    {
        newGame = false;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {      
        Application.Quit();
    }

    private Button continueGameButton;

    public void Start()
    {
        this.continueGameButton = Utils.getChildGameObject(this.transform, "ContinueGameButton").GetComponent<Button>();
        this.continueGameButton.interactable = SaveController.saveExists();
    }
}
