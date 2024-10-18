using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed;
    int life = 3;
    public Slider hpSlider;
    public GameObject diePanel;
    //SpriteRenderer sprite;

    private void Start()
    {
        diePanel.SetActive(false);
       // sprite = GetComponent<SpriteRenderer>();
        Time.timeScale = 1;
    }

    private void Update()
    {
        PlayerMove();
        hpSlider.value = life;
    }

    void PlayerMove()
    {
        //플레이어 움직임
        float h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h * moveSpeed * Time.deltaTime, 0, 0);
        float clampedX = Mathf.Clamp(transform.position.x, -2.2f, 2.2f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Poop"))
        {
            life--;
            /*if(life == 2)
            {
                sprite.color = new Color(255, 125, 0, 255);
            }
            if(life == 1)
            {
                sprite.color = new Color(99, 48, 0, 255);
            }*/
            if(life <= 0)
            {
                PlayerDie();
            }
        }
    }

    void PlayerDie()
    {
        diePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
