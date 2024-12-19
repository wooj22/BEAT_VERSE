using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_HitBeat : MonoBehaviour
{
    [SerializeField] ParticleSystem effect;
    [SerializeField] int maxCount = 2;
    private int hitCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightPlayer"))
        {
            Debug.Log("Hit");
            hitCount++;

            if (hitCount >= maxCount)
            {
                GetComponent<NoteMove>().isMove = false;
                effect.Play();
                SoundManager.Instance.PlaySFX("SFX_Hit");
                Invoke(nameof(Hit), 2f);
            }
        }
        else if (other.gameObject.CompareTag("DeadLine"))
        {
            this.gameObject.SetActive(false);
            hitCount = 0;
        }
    }

    private void Hit()
    {
        this.gameObject.SetActive(false);
        GetComponent<NoteMove>().isMove = true;
        hitCount = 0;
    }
}
