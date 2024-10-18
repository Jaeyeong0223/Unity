using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.F))
        {
            talkStep = 1;

            if (GameManager.Instance.hasNeck)
            {
                bearTalk.SetActive(true);
            }
            else
            {
                bingiTalk.SetActive(true);
            }
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
        switch(afterTalkStep)
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
                bingiText.text = "여기 누구 있나요? 저기요";
                talkStep++;
                break;
            case 2:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "안녕? 빙기야";
                talkStep++;
                break;
            case 3:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "어... 어떻게 제 이름을 아시나요?";
                talkStep++;
                break;
            case 4:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "당연히 알 수 밖에 너는 환생을 위해 첫번째 시련인\n 곰의 시련을 받기위해 온 아이 아니니";
                talkStep++;
                break;
            case 5:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "신님께 너에 대하여 설명을 들었어\n 너의 그 주인을 위한 마음가짐 대단해";
                talkStep++;
                break;
            case 6:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "아니에요 아직 많이 부족한걸요";
                talkStep++;
                break;
            case 7:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "허허 겸손하기도 하지";
                talkStep++;
                break;
            case 8:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "그러면 시련이라는게 뭔가요?";
                talkStep++;
                break;
            case 9:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "아... 이야기를 하다보니 시련에 대해 \n설명을 해주지 않았구나 미안하다";
                talkStep++;
                break;
            case 10:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "아니에요 저도 이야기 한다고 정말 즐거웠던 걸요";
                talkStep++;
                break;
            case 11:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "그럼 곰에 시련에 대해 설명을 해주마\n 곰의 시련의 주제는 달려라 라는 시험이다.";
                talkStep++;
                break;
            case 12:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "너는 목적지 까지 달리면서 장애물들을 피하고\n 뛰어넘어서 무사히 도착하면 이 시련은 통과야";
                talkStep++;
                break;
            case 13:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "그런가요. 근데 혹시 시련에 실패를 하게 되면\n 어떻게 되나요?";
                talkStep++;
                break;
            case 14:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "시련을 실패를 하면 성공할때 까지 다시하면 되\n 여튼 빙기야 꼭 시련을 통과하길 바란다.";
                talkStep++;
                break;
            default:
                SceneManager.LoadScene("BearGame");
                break;
        }
    }
}