using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    public Text text;
    public int poopCount = 0;

    private void Update()
    {
        text.text = "ÇÇÇÑ ¶Ë : " + poopCount.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        poopCount++;
    }
}
