using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] GameObject gameStartUI;
    [SerializeField] GameObject stageUI;
    [SerializeField] GameObject stageStartUI;
    [SerializeField] Text StageDescriptionText;
    [SerializeField] List<Image> fadeImageList;

    private int stageNum;

    // 메인 시작 버튼
    public void GameStartButton()
    {
        gameStartUI.SetActive(false);
        stageUI.SetActive(true);
    }

    // 스테이지 선택 뒤로 가기 버튼
    public void BackButton()
    {
        gameStartUI.SetActive(true);
        stageUI.SetActive(false);
    }

    // 스테이지 선택 버튼
    public void StageButton(int stageNum)
    {
        switch (stageNum)
        {
            case 1:
                StageDescriptionText.text = "Stage 1 \n Play?";
                stageNum = 1;
                break;
            case 2:
                StageDescriptionText.text = "Stage 2 \n Play?";
                stageNum = 2;
                break;
            case 3:
                StageDescriptionText.text = "Stage 3 \n Play?";
                stageNum = 3;
                break;

        }
        stageStartUI.SetActive(true);
    }

    // 스테이지 시작 버튼
    public void StageStartButton()
    {
        PlayerPrefs.SetInt("StageNum", stageNum);
        StartCoroutine(FadeOut());
    }

    // 페이드아웃
    IEnumerator FadeOut()
    {
        for(int i=0; i< fadeImageList.Count; i++)
        {
            fadeImageList[i].gameObject.SetActive(true);
        }

        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);

            for (int i = 0; i < fadeImageList.Count; i++)
            {
                fadeImageList[i].color = new Color(0, 0, 0, fadeCount);
            }
        }

        yield return new WaitForSeconds(3f);
        SceneSwitch.Instance.SceneSwithcing("MainGame");
    }
}
