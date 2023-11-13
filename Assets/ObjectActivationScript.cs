using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivationScript : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem PE;

    private void Start()
    {
        if (PE != null)
        {
            PE.Stop();
        }
    }

    private void OnEnable()
    {
        if (PE != null)
        {
            PE.Play();
        }
    }

    private void OnDisable()
    {
        if (PE != null)
        {
            PE.Stop();
        }
    }
}
