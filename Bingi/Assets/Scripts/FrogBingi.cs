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
                bingiText.text = "���� ����� �ʴ� ����� �翬��\n ����� �� �˰� �־��� �� �̰Ŵ� �÷������ ��ǥ �����̾�";
                talkStep++;
                break;
            case 2:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "�׸��� ���� �ŴԲ��� ��ٸ��ô� �ٷ� �������� �����ٲ�\n ����� �� �÷� ����ؼ� ȯ���ϱ⸦ �ٶ�";
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
                bingiText.text = "�̹����� �����̳�";
                talkStep++;
                break;
            case 2:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "�������� �ȳ� �����\n���� ������ �÷��� ���� �������� ����";
                talkStep++;
                break;
            case 3:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "��濡 ó�� �ִ� 3������ ���� �������� �� �ʸӷ�\n�����ϰ� ��������";
                talkStep++;
                break;
            case 4:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "�� �Ѹ����� ���������� ���ϸ� ���о� ����";
                talkStep++;
                break;
            case 5:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "�׷� ����� ���� ����";
                talkStep++;
                break;
            default:
                SceneManager.LoadScene("FrogGame");
                break;
        }
    }
}
