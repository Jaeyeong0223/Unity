using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDie : MonoBehaviour
{
    public GameObject ground;
    public Button restartButton, mainmenuButton;
    public Text text;

    private void Update()
    {
        text.text = "ÇÇÇÑ ¶Ë : " + ground.GetComponentInChildren<Ground>().poopCount.ToString();
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("Title");
    }
}
