using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Froger : MonoBehaviour
{
    public float speed;
    public GameObject canvas;
    public GameObject arrow;
    private bool onLog;
    private Vector2 logVelocity;
    public Image frog, frog2, frog3;
    int frogCount = 0;
    bool hasFrog;

    private void Start()
    {
        canvas.SetActive(false);
        arrow.SetActive(true);
        StartCoroutine(Arrow());
        hasFrog = true;
    }

    IEnumerator Arrow()
    {
        yield return new WaitForSeconds(1f);
        arrow.SetActive(false);
    }

    private void Update()
    {
        FroggerMove();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            canvas.SetActive(true);
            StartCoroutine(GameRestart());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal") && hasFrog == true)
        {
            hasFrog = false;
            frogCount++;
            if(frogCount == 1)
            {
                frog.color = new Color(255, 255, 255);
            }
            if (frogCount == 2)
            {
                frog2.color = new Color(255, 255, 255);
            }
            if (frogCount == 3)
            {
                frog3.color = new Color(255, 255, 255);
                GameManager.Instance.hasName = true;
                SceneManager.LoadScene("DogGod");
            }
        }
        if(collision.gameObject.CompareTag("Frog"))
        {
            hasFrog = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Log1") || collision.gameObject.CompareTag("Log2") || collision.gameObject.CompareTag("Log3"))
        {
            onLog = true;
            logVelocity = collision.GetComponent<Rigidbody2D>().velocity;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Log1") || collision.gameObject.CompareTag("Log2") || collision.gameObject.CompareTag("Log3"))
        {
            onLog = false;
        }
    }

    IEnumerator GameRestart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("FrogGame");
    }

    void FroggerMove()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.W))
        {
            movement += Vector3.up * speed;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movement += Vector3.down * speed;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movement += Vector3.left * speed;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement += Vector3.right * speed;
        }

        transform.Translate(movement);

        if (onLog)
        {
            transform.position += (Vector3)logVelocity * Time.deltaTime;
        }
    }
}
