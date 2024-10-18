using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public Image neck, nameTeck, bell;

    private void Update()
    {
        ItemColor();    
    }

    void ItemColor()
    {
        if (GameManager.Instance.hasNeck == true)
        {
            neck.color = new Color(255, 255, 255);
        }
        if (GameManager.Instance.hasName == true)
        {
            nameTeck.color = new Color(255, 255, 255);
        }
        if (GameManager.Instance.hasBell == true)
        {
            bell.color = new Color(255, 255, 255);
        }
    }
}
