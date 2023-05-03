using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luigi : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.Play();
    }
}
