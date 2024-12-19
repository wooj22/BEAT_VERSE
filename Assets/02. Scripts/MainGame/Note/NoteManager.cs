using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private float nomalThreshold; // 노말비트 감지 임계값
    [SerializeField] private float hitThreshold;   // 히트비트 감지 임계값
    [SerializeField] private float crashThreshold; // 크래쉬비트 감지 임계값

    private NoteGenerator noteGenerator;
    private AudioSource currentBGM;         
    private float[] audioSamples = new float[1024];     // 주파수 데이터 버퍼
    private Coroutine co;

    private void Start()
    {
        noteGenerator = GetComponent<NoteGenerator>();
    }

    public void NoteCreatingStart()
    {
        co = StartCoroutine(NoteCreating());
    }

    public void NoteCreatingStop()
    {
        StopCoroutine(co);
    }

    // BGM 주파수 계산 -> 노트 생성
    IEnumerator NoteCreating()
    {
        currentBGM = SoundManager.Instance.GetBgmSource();
        while (true)
        {
            // 주파수 데이터
            currentBGM.GetSpectrumData(audioSamples, 0, FFTWindow.Hamming);

            // 주파수 감지
            float totalEnergy = 0f;
            for (int i = 0; i < audioSamples.Length; i++)
            {
                totalEnergy += audioSamples[i];
            }

            // 임계값 계산, 노트 생성 명령
            if (totalEnergy > crashThreshold)
            {
                noteGenerator.BeatChoice(1);
            }
            else if (totalEnergy > hitThreshold)
            {
                noteGenerator.BeatChoice(2);
            }
            else if (totalEnergy > nomalThreshold)
            {
                noteGenerator.BeatChoice(3);
            }

            yield return new WaitForSeconds(1f);
            Debug.Log("임계값 계산" + totalEnergy);
        }
    }
}
