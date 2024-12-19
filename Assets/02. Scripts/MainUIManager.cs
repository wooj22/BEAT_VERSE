using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] GameObject startInfoUI;
    [SerializeField] GameObject controlInfoUI;
    [SerializeField] Text stageNameText;
    [SerializeField] Text adviceLable;
    [SerializeField] List<Image> fadeImageList;

    private bool isStoped;

    private void Start()
    {
        StartCoroutine(StartInfoUI());
    }

    // 게임 정보 UI
    public IEnumerator StartInfoUI()
    {
        StartCoroutine(FadeIn());

        // 스테이지 정보
        // 게임매니저에서 스테이지 정보 받아오는거 추가하기
        stageNameText.text = "Stage 1"; 
        yield return new WaitForSeconds(5f);

        // 게임설명
        startInfoUI.SetActive(false);
        controlInfoUI.SetActive(true);
    }

    // 게임 시작 UI
    public void OkButton()
    {
        StartCoroutine(GameStartUI());
    }

    IEnumerator GameStartUI()
    {
        // 준비
        controlInfoUI.SetActive(false);
        adviceLable.gameObject.SetActive(true);
        AdviceLable("Ready...");
        yield return new WaitForSeconds(3f);

        // 시작
        AdviceLable("Start!");
        yield return new WaitForSeconds(3f);
        AdviceLable("");
    }

    // 보조라벨
    public void AdviceLable(string text)
    {
        adviceLable.text = text;
    }

    // 게임 중지
    public void StopButton()
    {
        if (!isStoped)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        
    }

    // 페이드인
    IEnumerator FadeIn()
    {
        float fadeCount = 1;
        while (fadeCount > 0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);

            for (int i = 0; i < fadeImageList.Count; i++)
            {
                fadeImageList[i].color = new Color(0, 0, 0, fadeCount);
            }
        }

        for (int i = 0; i < fadeImageList.Count; i++)
        {
            fadeImageList[i].gameObject.SetActive(false);
        }
    }

    // 페이드아웃
    IEnumerator FadeOut()
    {
        for (int i = 0; i < fadeImageList.Count; i++)
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
        SceneSwitch.Instance.SceneSwithcing("MainMenu");
    }
}
