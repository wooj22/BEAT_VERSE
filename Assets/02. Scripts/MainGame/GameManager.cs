using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stageNum;    // 스테이지 정보
    private NoteManager noteManager;

    // 싱글톤
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

    // 스테이지 셋팅
    private void StageSetting()
    {
        stageNum = PlayerPrefs.GetInt("StageNum", 1);

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

    // 게임 시작
    public void GameStart()
    {
        noteManager.NoteCreatingStart();    // 노트 생성 시작
        Debug.Log("Game Start");
    }

    public void GameEnd()
    {
        noteManager.NoteCreatingStop();    // 노트 생성 중단
    }
}
