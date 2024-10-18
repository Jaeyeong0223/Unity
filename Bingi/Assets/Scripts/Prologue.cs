using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Prologue : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(PrologueEnd());
    }

    IEnumerator PrologueEnd()
    {
        yield return new WaitForSeconds(18f);
        SceneManager.LoadScene("DogGod");
    }
}
