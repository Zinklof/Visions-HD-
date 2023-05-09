using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementEntranceAnimator : MonoBehaviour
{
    public GameObject animatedCamera;
    public GameObject player;

    IEnumerator WaitForEntranceEnding()
    {
        yield return new WaitForSecondsRealtime(12.33f);
        animatedCamera.SetActive(false);
        player.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine(WaitForEntranceEnding());
    }
}
