using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Talk : MonoBehaviour
{
    public GameObject bingiTalk;
    public Text godText, bingiText;
    private int talkStep = 0;

    private void Start()
    {
        bingiTalk.SetActive(false);
        godText.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            bingiTalk.SetActive(true);
            //talkStep = 1;
            talkStep++;

            AdvanceConversation();
        }
    }

    void AdvanceConversation()
    {
        switch (talkStep)
        {
            case 1:
                bingiTalk.SetActive(true);
                bingiText.text = "���� �и� ���� ������ ���ϴٰ� �׾��µ�...\n ��°�� ���� ���� �߰� �ִ°���? �׸��� ����� ....?";
                //talkStep++;
                break;
            case 2:
                bingiTalk.SetActive(false);
                godText.enabled= true;
                godText.text = "�������� �ʴ� �и� �׾���. �׸��� ����� �����Ǿ��̴϶� ";
                //talkStep++;
                break;
            case 3:
                bingiTalk.SetActive(true);
                godText.enabled = false;
                bingiText.text = "�׷��� ��°�� ���� �� �����ǾƷ� ����?\n���� �и� �׾��µ�..?";
                //talkStep++;
                break;
            case 4:
                bingiTalk.SetActive(false);
                godText.enabled = true;
                godText.text = "�翬�� �� �� �ۿ� �ʴ� ȯ���� ���� ù��° �÷���\n ���� �÷��� �ޱ����� �� ���� �ƴϴ�";
                //talkStep++;
                break;
            case 5:
                bingiTalk.SetActive(false);
                godText.text = "���� ���� ������ ������ ���� ��� �ϴ� ���̴� ���� ģ�� �ʸ� �ҷ����϶�";
                //talkStep++;
                break;
            case 6:
                bingiTalk.SetActive(false);
                godText.text = "����� �ʴ� ������ ���ϱ����� ���� ����� �������鼭 ������ ���� ���״��϶�\n���� �� �밨�� ���ÿ� �ʿ��� ���ñ��� �ְڳ��";
                //talkStep++;
                break;
            case 7:
                bingiTalk.SetActive(true);
                godText.enabled = false;
                bingiText.text = "���ñ�...";
                //talkStep++;
                break;
            case 8:
                bingiTalk.SetActive(false);
                godText.enabled = true;
                godText.text = "ù������ �� �����Ǿƿ� ���� �ູ�ϰ� ��°�\n�ι�°�� ȯ���Ͽ� ���������� �ٽ��ѹ� �����°� �ʴ� ������ ������ ���̳�?";
                //talkStep++;
                break;
            case 9:
                bingiTalk.SetActive(true);
                godText.enabled = false;
                bingiText.text = "���� �����Ǿƿ� ���� �ູ�ϰ� ��°͵� ������\n ������ ���� ���� �Ⱥ��̰� �Ǿ� �ʹ� ������ �ſ�.";
                //talkStep++;
                break;
            case 10:
                bingiTalk.SetActive(true);
                bingiText.text = "��� ���� ���ϰ� ��� ���� �����ؿ� �׷��ϱ�\n���� ȯ���� �Ͽ� �ٽ��ѹ� ������ ������ �;��.";
                //talkStep++;
                break;
            case 11:
                bingiTalk.SetActive(false);
                godText.enabled = true;
                godText.text = "���� ������ �����ϴ� �� �������� ��Ư�ϱ��� �׷� ȯ���� �����ϴ� ���̳�?\nȯ���� 3���� �÷��� �ѱ�� ���� ��ǰ�� ���ľ�����  ��μ� ȯ���� �� �� �ִ�";
                //talkStep++;
                break;
            case 12:
                bingiTalk.SetActive(false);
                godText.text = "�ѹ� �����غ��ڴ���?";
                //talkStep++;
                break;
            case 13:
                bingiTalk.SetActive(true);
                godText.enabled = false;
                bingiText.text = "�ٽ��ѹ� ������ ������ ���ؼ���� �������� �ʰ�\n�÷��� ����Ұſ���.";
                //talkStep++;
                break;
            case 14:
                bingiTalk.SetActive(false);
                godText.enabled = true;
                godText.text = "���� �׷� ���� ���տ� ���̴� �� ��Ż�� ���� �÷��� ������ �������ƶ�.";
                //talkStep++;
                break;
            case 15:
                bingiTalk.SetActive(true);
                godText.enabled = false;
                bingiText.text = "�˰ڽ��ϴ�";
                //talkStep++;
                break;
            case 16:
                bingiTalk.SetActive(false);
                godText.enabled = true;
                godText.text = "����� ����� ����϶�.";
                GameManager.Instance.bearDoor.SetActive(true);
                //talkStep++;
                break;
            default:
                bingiTalk.SetActive(false);
                godText.enabled = false;
                break;
        }
    }
}
