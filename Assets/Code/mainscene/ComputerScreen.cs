using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScreen : MonoBehaviour
{
    public CanvasGroup canvas;

    private bool computerHasBeenAproached;

    private void OnTriggerEnter(Collider other)
    {
        if (!computerHasBeenAproached)
        StartCoroutine(PutComputerOnScreen());
    }

    IEnumerator PutComputerOnScreen()
    {
        computerHasBeenAproached = true;
        canvas.alpha = 1f;
        yield return new WaitForSecondsRealtime(4f);
        canvas.alpha = 0f;
    }
}
