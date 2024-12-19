using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_HitBeat : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer obRenderer;
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
                obRenderer.enabled = false;
                effect.Play();
                SoundManager.Instance.PlaySFX("SFX_Hit");
                Invoke(nameof(Hit), 1f);

                GameManager.Instance.Hit();
            }
        }
        else if (other.gameObject.CompareTag("DeadLine"))
        {
            this.gameObject.SetActive(false);
            hitCount = 0;

            GameManager.Instance.Lose();
        }
    }

    private void Hit()
    {
        this.gameObject.SetActive(false);
        GetComponent<NoteMove>().isMove = true;
        obRenderer.enabled = true;
        hitCount = 0;
    }
}
