using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private float nomalThreshold; // �븻��Ʈ ���� �Ӱ谪
    [SerializeField] private float hitThreshold;   // ��Ʈ��Ʈ ���� �Ӱ谪
    [SerializeField] private float crashThreshold; // ũ������Ʈ ���� �Ӱ谪

    private NoteGenerator noteGenerator;
    private AudioSource currentBGM;         
    private float[] audioSamples = new float[1024];     // ���ļ� ������ ����
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

    // BGM ���ļ� ��� -> ��Ʈ ����
    IEnumerator NoteCreating()
    {
        currentBGM = SoundManager.Instance.GetBgmSource();
        while (true)
        {
            // ���ļ� ������
            currentBGM.GetSpectrumData(audioSamples, 0, FFTWindow.Hamming);

            // ���ļ� ����
            float totalEnergy = 0f;
            for (int i = 0; i < audioSamples.Length; i++)
            {
                totalEnergy += audioSamples[i];
            }

            // �Ӱ谪 ���, ��Ʈ ���� ���
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
            Debug.Log("�Ӱ谪 ���" + totalEnergy);
        }
    }
}
