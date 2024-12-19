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

    // ���� ���� ��ư
    public void GameStartButton()
    {
        gameStartUI.SetActive(false);
        stageUI.SetActive(true);
    }

    // �������� ���� �ڷ� ���� ��ư
    public void BackButton()
    {
        gameStartUI.SetActive(true);
        stageUI.SetActive(false);
    }

    // �������� ���� ��ư
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

    // �������� ���� ��ư
    public void StageStartButton()
    {
        PlayerPrefs.SetInt("StageNum", stageNum); 
        //int stageNum = PlayerPrefs.GetInt("StageNum", 1);
    }
}
