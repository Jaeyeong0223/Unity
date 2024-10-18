using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button startButton;

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
