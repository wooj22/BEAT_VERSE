using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    [Header ("Beat Models")]
    [SerializeField] GameObject L_NomalBeat;
    [SerializeField] GameObject R_NomalBeat;
    [SerializeField] GameObject L_HitBeat;
    [SerializeField] GameObject R_HitBeat;
    [SerializeField] GameObject CrashBeat;

    [Header("Pulling Data")]
    [SerializeField] int LN_pmc;    // L_NomalBeat Pulling Max Count
    [SerializeField] int RN_pmc;    // R_NomalBeat Pulling Max Count
    [SerializeField] int LH_pmc;    // L_HitBeat Pulling Max Count
    [SerializeField] int RH_pmc;    // R_HitBeat Pulling Max Count
    [SerializeField] int C_pmc;     // CrashBeat Pulling Max Count
    [SerializeField] Transform pos;
    [SerializeField] Transform parents;

    private List<Vector3> startPosList = new List<Vector3>();
    private List<GameObject> lnList = new List<GameObject>();
    private List<GameObject> rnList = new List<GameObject>();
    private List<GameObject> lhList = new List<GameObject>();
    private List<GameObject> rhList = new List<GameObject>();
    private List<GameObject> cList = new List<GameObject>();


    private void Start()
    {
        SetPosition();
        ObjectPulling(L_NomalBeat, LN_pmc, lnList);
        ObjectPulling(R_NomalBeat, RN_pmc, rnList);
        ObjectPulling(L_HitBeat, LH_pmc, lhList);
        ObjectPulling(R_HitBeat, RH_pmc, rhList);
        ObjectPulling(CrashBeat, C_pmc, cList);
    }

    // 비트 생성 포지션 set
    private void SetPosition()
    {
        foreach (Transform child in pos)
        {
            startPosList.Add(child.position);
        }
    }

    // 비트 생성 포지션 get
    private Vector3 GetPosition()
    {
        int randomIndex = Random.Range(0, startPosList.Count);
        return startPosList[randomIndex];
    }

    // 오브젝트 풀링
    private void ObjectPulling(GameObject prefabs, int maxCount, List<GameObject> list)
    {
        for (int i = 0; i < maxCount; i++)
        {
            GameObject beat = Instantiate(prefabs, GetPosition(), Quaternion.identity);
            beat.transform.SetParent(parents);
            //beat.SetActive(false);
            list.Add(beat);
        }
    }
}
