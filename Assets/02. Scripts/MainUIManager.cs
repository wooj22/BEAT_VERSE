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

    // ���� ���� UI
    public IEnumerator StartInfoUI()
    {
        StartCoroutine(FadeIn());

        // �������� ����
        // ���ӸŴ������� �������� ���� �޾ƿ��°� �߰��ϱ�
        stageNameText.text = "Stage 1"; 
        yield return new WaitForSeconds(5f);

        // ���Ӽ���
        startInfoUI.SetActive(false);
        controlInfoUI.SetActive(true);
    }

    // ���� ���� UI
    public void OkButton()
    {
        StartCoroutine(GameStartUI());
    }

    IEnumerator GameStartUI()
    {
        // �غ�
        controlInfoUI.SetActive(false);
        adviceLable.gameObject.SetActive(true);
        AdviceLable("Ready...");
        yield return new WaitForSeconds(3f);

        // ����
        AdviceLable("Start!");
        yield return new WaitForSeconds(3f);
        AdviceLable("");
    }

    // ������
    public void AdviceLable(string text)
    {
        adviceLable.text = text;
    }

    // ���� ����
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

    // ���̵���
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

    // ���̵�ƿ�
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
