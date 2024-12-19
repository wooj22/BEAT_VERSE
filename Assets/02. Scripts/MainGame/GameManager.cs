using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float playTime;
    [SerializeField] private GameObject notes;
    public int stageNum;

    private int hitCount;
    private int loseCount;
    private NoteManager noteManager;

    // �̱���
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        noteManager = GameObject.Find("Note").GetComponent<NoteManager>();
        StageSetting();
    }

    // �������� ����
    private void StageSetting()
    {
        stageNum = PlayerPrefs.GetInt("StageNum", 1);
        hitCount = 0;
        loseCount = 0;

        switch (stageNum)
        {
            case 1:
                SoundManager.Instance.SetBGM("BGM_Stage1");
                break;
            case 2:
                SoundManager.Instance.SetBGM("BGM_Stage1");
                break;
            case 3:
                SoundManager.Instance.SetBGM("BGM_Stage1");
                break;
            default:
                SoundManager.Instance.SetBGM("BGM_Stage1");
                break;
        }

        SoundManager.Instance.FadeInBGM();
        MainUIManager.Instance.UIStart(stageNum);
    }

    // ���� ����
    public void GameStart()
    {
        noteManager.NoteCreatingStart();    // ��Ʈ ���� ����
        StartCoroutine(GameTime());
    }

    // ���� �ð� üũ
    IEnumerator GameTime()
    {
        int time = 0;
        while(time < playTime)
        {
            yield return new WaitForSeconds(1f);
            time++;
        }
        GameEnd();
    }

    public void Hit()
    {
        hitCount++;
    }

    public void Lose()
    {
        loseCount++;
    }

    public void GameEnd()
    {
        noteManager.NoteCreatingStop();    // ��Ʈ ���� �ߴ�
        notes.SetActive(false);
        SoundManager.Instance.FadeOutBGM();
        SoundManager.Instance.PlaySFX("SFX_GameEnd");
        MainUIManager.Instance.GameEndUI(hitCount, loseCount);
    }
}
