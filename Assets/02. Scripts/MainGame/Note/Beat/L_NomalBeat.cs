using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_NomalBeat : MonoBehaviour
{
    [SerializeField] ParticleSystem effect;
    [SerializeField] int maxCount = 1;
    private int hitCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftPlayer"))
        {
            hitCount++;

            if (hitCount >= maxCount)
            {
                effect.Play();
                this.gameObject.SetActive(false);
                hitCount = 0;
            }
        }
        else if (other.gameObject.CompareTag("DeadLine"))
        {
            this.gameObject.SetActive(false);
            hitCount = 0;
        }
    }
}
