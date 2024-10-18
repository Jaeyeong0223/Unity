using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Button optionButton;
    public GameObject titleCanvas;
    public GameObject optionCanvas;

    private void Start()
    {
        optionCanvas.SetActive(false);
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Prologue");
    }

    public void OnOptionButtonClick()
    {
        titleCanvas.SetActive(false);
        optionCanvas.SetActive(true);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
