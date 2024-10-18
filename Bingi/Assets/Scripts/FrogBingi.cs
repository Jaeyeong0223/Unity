using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FrogBingi : MonoBehaviour
{
    [SerializeField]
    int speed = 10;
    Rigidbody2D rb;
    public GameObject bearTalk, bingiTalk;
    Animator anim;
    public Text bearText, bingiText;

    private int talkStep = 0;
    private int afterTalkStep = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bingiTalk.SetActive(false);
        bearTalk.SetActive(false);
    }

    private void Update()
    {
        Move();
        Talk();
        AfterTalk();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
            anim.SetBool("isWalk", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            talkStep = 1;
            bingiTalk.SetActive(true);
        }
    }

    void Talk()
    {
        if (bingiTalk.activeSelf || bearTalk.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                AdvanceConversation();
            }
        }
    }

    void AfterTalk()
    {
        if (bingiTalk.activeSelf || bearTalk.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                AdvanceConversation2();
            }
        }
    }

    void AdvanceConversation2()
    {
        switch (afterTalkStep)
        {
            case 1:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "역시 빙기야 너는 대단해 당연히\n 통과할 줄 알고 있었어 자 이거는 시련통과의 증표 목줄이야";
                talkStep++;
                break;
            case 2:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "그리고 지금 신님께서 기다리시니 바로 그쪽으로 보내줄께\n 빙기야 꼭 시련 통과해서 환생하기를 바라마";
                talkStep++;
                break;
        }
    }

    void AdvanceConversation()
    {
        switch (talkStep)
        {
            case 1:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "이번에는 연못이네";
                talkStep++;
                break;
            case 2:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "개굴개굴 안녕 빙기야\n나는 연못의 시련의 주인 개구리야 개굴";
                talkStep++;
                break;
            case 3:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "곤경에 처해 있는 3마리의 작은 개구리를 강 너머로\n안전하게 데려다줘";
                talkStep++;
                break;
            case 4:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "단 한마리라도 데려다주지 못하면 실패야 개굴";
                talkStep++;
                break;
            case 5:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "그럼 행운을 빌게 개굴";
                talkStep++;
                break;
            default:
                SceneManager.LoadScene("FrogGame");
                break;
        }
    }
}
