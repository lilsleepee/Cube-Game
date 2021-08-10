using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;

    private void Awake()
    {
        StartCoroutine(Autodestroy());
    }

    IEnumerator Autodestroy()
    {
        yield return new WaitForSeconds(particleSystem.duration);
        Destroy(this.gameObject);
    }
}
