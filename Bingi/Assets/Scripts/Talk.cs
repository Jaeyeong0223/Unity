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
                bingiText.text = "뭐지 분명 나는 주인을 구하다가 죽었는데...\n 어째서 내가 눈을 뜨고 있는거지? 그리고 여기는 ....?";
                //talkStep++;
                break;
            case 2:
                bingiTalk.SetActive(false);
                godText.enabled= true;
                godText.text = "허허허허 너는 분명 죽었다. 그리고 여기는 개토피아이니라 ";
                //talkStep++;
                break;
            case 3:
                bingiTalk.SetActive(true);
                godText.enabled = false;
                bingiText.text = "그러면 어째서 제가 이 개토피아로 왔죠?\n저는 분명 죽었는데..?";
                //talkStep++;
                break;
            case 4:
                bingiTalk.SetActive(false);
                godText.enabled = true;
                godText.text = "당연히 알 수 밖에 너는 환생을 위해 첫번째 시련인\n 곰의 시련을 받기위해 온 아이 아니니";
                //talkStep++;
                break;
            case 5:
                bingiTalk.SetActive(false);
                godText.text = "허허 너의 죽음은 마땅히 상을 줘야 하는 일이니 내가 친히 너를 불렀느니라";
                //talkStep++;
                break;
            case 6:
                bingiTalk.SetActive(false);
                godText.text = "빙기야 너는 주인을 구하기위해 너의 목숨을 버려가면서 주인을 끝내 지켰느니라\n너의 그 용감한 선택에 너에게 선택권을 주겠노라";
                //talkStep++;
                break;
            case 7:
                bingiTalk.SetActive(true);
                godText.enabled = false;
                bingiText.text = "선택권...";
                //talkStep++;
                break;
            case 8:
                bingiTalk.SetActive(false);
                godText.enabled = true;
                godText.text = "첫번쨰는 이 개토피아에 남아 행복하게 사는것\n두번째는 환생하여 원래주인을 다시한번 만나는것 너는 무엇을 선택할 것이냐?";
                //talkStep++;
                break;
            case 9:
                bingiTalk.SetActive(true);
                godText.enabled = false;
                bingiText.text = "저는 개토피아에 남아 행복하게 사는것도 좋지만\n 주인이 사고로 눈이 안보이게 되어 너무 걱정이 돼요.";
                //talkStep++;
                break;
            case 10:
                bingiTalk.SetActive(true);
                bingiText.text = "어떻게 저만 편하게 사는 길을 선택해요 그러니까\n저는 환생을 하여 다시한번 주인을 만나고 싶어요.";
                //talkStep++;
                break;
            case 11:
                bingiTalk.SetActive(false);
                godText.enabled = true;
                godText.text = "허허 주인을 생각하는 그 마음가짐 기특하구나 그럼 환생을 선택하는 것이냐?\n환생은 3가지 시련을 넘기고 받은 물품을 합쳐야지만  비로소 환생을 할 수 있다";
                //talkStep++;
                break;
            case 12:
                bingiTalk.SetActive(false);
                godText.text = "한번 도전해보겠느냐?";
                //talkStep++;
                break;
            case 13:
                bingiTalk.SetActive(true);
                godText.enabled = false;
                bingiText.text = "다시한번 주인을 만나기 위해서라면 망설이지 않고\n시련을 통과할거에요.";
                //talkStep++;
                break;
            case 14:
                bingiTalk.SetActive(false);
                godText.enabled = true;
                godText.text = "좋다 그럼 지금 눈앞에 보이는 이 포탈로 들어가서 시련의 주인을 만나보아라.";
                //talkStep++;
                break;
            case 15:
                bingiTalk.SetActive(true);
                godText.enabled = false;
                bingiText.text = "알겠습니다";
                //talkStep++;
                break;
            case 16:
                bingiTalk.SetActive(false);
                godText.enabled = true;
                godText.text = "빙기야 행운을 비느니라.";
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
