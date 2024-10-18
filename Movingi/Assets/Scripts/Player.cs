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
                bingiText.text = "���� ���� �ֳ���? �����";
                talkStep++;
                break;
            case 2:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "�ȳ�? �����";
                talkStep++;
                break;
            case 3:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "��... ��� �� �̸��� �ƽó���?";
                talkStep++;
                break;
            case 4:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "�翬�� �� �� �ۿ� �ʴ� ȯ���� ���� ù��° �÷���\n ���� �÷��� �ޱ����� �� ���� �ƴϴ�";
                talkStep++;
                break;
            case 5:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "�ŴԲ� �ʿ� ���Ͽ� ������ �����\n ���� �� ������ ���� �������� �����";
                talkStep++;
                break;
            case 6:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "�ƴϿ��� ���� ���� �����Ѱɿ�";
                talkStep++;
                break;
            case 7:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "���� ����ϱ⵵ ����";
                talkStep++;
                break;
            case 8:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "�׷��� �÷��̶�°� ������?";
                talkStep++;
                break;
            case 9:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "��... �̾߱⸦ �ϴٺ��� �÷ÿ� ���� \n������ ������ �ʾұ��� �̾��ϴ�";
                talkStep++;
                break;
            case 10:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "�ƴϿ��� ���� �̾߱� �Ѵٰ� ���� ��ſ��� �ɿ�";
                talkStep++;
                break;
            case 11:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "�׷� ���� �÷ÿ� ���� ������ ���ָ�\n ���� �÷��� ������ �޷��� ��� �����̴�.";
                talkStep++;
                break;
            case 12:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "�ʴ� ������ ���� �޸��鼭 ��ֹ����� ���ϰ�\n �پ�Ѿ ������ �����ϸ� �� �÷��� �����";
                talkStep++;
                break;
            case 13:
                bingiTalk.SetActive(true);
                bearTalk.SetActive(false);
                bingiText.text = "�׷�����. �ٵ� Ȥ�� �÷ÿ� ���и� �ϰ� �Ǹ�\n ��� �ǳ���?";
                talkStep++;
                break;
            case 14:
                bingiTalk.SetActive(false);
                bearTalk.SetActive(true);
                bearText.text = "�÷��� ���и� �ϸ� �����Ҷ� ���� �ٽ��ϸ� ��\n ��ư ����� �� �÷��� ����ϱ� �ٶ���.";
                talkStep++;
                break;
            default:
                SceneManager.LoadScene("BearGame");
                break;
        }
    }
}