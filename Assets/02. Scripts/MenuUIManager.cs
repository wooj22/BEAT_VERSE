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
                StageDescriptionText.text = "Stage 1 \n Fun Fun";
                stageNum = 1;
                break;
            case 2:
                StageDescriptionText.text = "Stage 2 \n dddddd";
                stageNum = 2;
                break;
            case 3:
                StageDescriptionText.text = "Stage 3 \n cccccccc";
                stageNum = 3;
                break;

        }
        stageStartUI.SetActive(true);
    }

    // 스테이지 시작 버튼
    public void StageStartButton()
    {
        PlayerPrefs.SetInt("StageNum", stageNum); 
        //int stageNum = PlayerPrefs.GetInt("StageNum", 1);
    }
}
