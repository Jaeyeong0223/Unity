using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlatformPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jump;
    int jumpCnt = 0;
    public Slider slider;
    public Text lifeText;
    int life;
    public GameObject bearTalk;
    public Text bearTxt;
    private bool hasNeckConversation = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        life = 3;
        bearTalk.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        slider.value += speed * Time.deltaTime;
        Jump();
        lifeText.text = "X" + life.ToString();
        BingiDie();
        if (hasNeckConversation && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("DogGod");
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && jumpCnt < 2)
        {
            rb.velocity = Vector2.up * jump;
            jumpCnt++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpCnt = 0;
        }
        if(collision.gameObject.CompareTag("Log"))
        {
            speed = 2;
            Destroy(collision.gameObject);
            life--;
            StartCoroutine(BingiSpeed());
        }
        if(collision.gameObject.CompareTag("DeadZone"))
        {
            life = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Neck"))
        {
            GameManager.Instance.hasNeck = true;
            bearTalk.SetActive(true);
            bearTxt.text = "���� ����� �ʴ� ����� �翬�� ����� �� �˰� �־���\n ���� �ŴԲ��� ��ٸ��ô� �ٷ� �������� �����ٲ�";
            hasNeckConversation = true;
            speed = 0;
        }
    }

    IEnumerator BingiSpeed()
    {
        yield return new WaitForSeconds(1f);
        speed = 7f;
    }

    void BingiDie()
    {
        if(life == 0)
        {
            bearTalk.SetActive(true);
            StartCoroutine(BearText());
        }
    }

    IEnumerator BearText()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("BearGame");
    }
}
