using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cole : MonoBehaviour
{
    public CanvasGroup canvas;
    public AudioSource audioSource;

    public void OnMouseDown()
    {
        StartCoroutine(RunCole());
    }

    public IEnumerator RunCole()
    {
        audioSource.Play();
        yield return new WaitForSecondsRealtime(0.5f);
        canvas.alpha = 1f;
        yield return new WaitForSecondsRealtime(1.2f);
        canvas.alpha = 0f;
    }
}
