using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CrowBingi : MonoBehaviour
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
            bearTalk.SetActive(true);
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
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "까악 뭐야 통과한거야? 별거 없는 놈이라고 생각했는데\n기여코 여기까지 왔네";
                talkStep++;
                break;
            case 2:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "이번 시련은 어떤 시련이야?\n아무리 어려운 시련이라도 꼭 통과하고 말겠어";
                talkStep++;
                break;
            case 3:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "까악 의욕만 앞서다니...\n뭐 니놈이 해낼거라는 생각은 하지 않지만";
                talkStep++;
                break;
            case 4:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "이번 시련을 말해주지 앞에보이는 사진을 원래대로 맞춰봐\n기대는 안하지만 행운을 빌지";
                talkStep++;
                break;
            default:
                SceneManager.LoadScene("CrowGame");
                break;
        }
    }
}
