using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class BingiScaleUp : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    GameObject keyCodeF, keyCodeF2, keyCodeF3;
    [SerializeField]
    GameObject bearDoor, frogDoor, crowDoor, lastDoor, Talk;
    Animator anim;
    


    private void Start()
    {
        anim = GetComponent<Animator>();
        keyCodeF.SetActive(false);
        keyCodeF2.SetActive(false);
        keyCodeF3.SetActive(false);
    }
    private void Update()
    {
        Move();
        Door();
    }

    void Door()
    {
        if(GameManager.Instance.hasNeck == true)
        {
            frogDoor.SetActive(true);
            Talk.SetActive(false);
        }
        if(GameManager.Instance.hasNeck == true && GameManager.Instance.hasName)
        {
            crowDoor.SetActive(true);
            frogDoor.SetActive(false);
            Talk.SetActive(false);
        }
        if (GameManager.Instance.hasNeck == true && GameManager.Instance.hasName && GameManager.Instance.hasBell)
        {
            lastDoor.SetActive(true);
            crowDoor.SetActive(false);
            frogDoor.SetActive(false);
            Talk.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BearDoor"))
        {
            keyCodeF.SetActive(true);
            if(Input.GetKey(KeyCode.F))
            {
                SceneManager.LoadScene("Bear");
            }
        }
        if (collision.gameObject.CompareTag("FrogDoor"))
        {
            keyCodeF2.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                SceneManager.LoadScene("Frog");
            }
        }
        if (collision.gameObject.CompareTag("CrowDoor"))
        {
            keyCodeF3.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                SceneManager.LoadScene("Crow");
            }
        }
        if (collision.gameObject.CompareTag("LastDoor"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                SceneManager.LoadScene("Ending");
            }
        }
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
            anim.SetBool("isWalk", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
            anim.SetBool("isWalk", true);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
            anim.SetBool("isWalk", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

    }
}
