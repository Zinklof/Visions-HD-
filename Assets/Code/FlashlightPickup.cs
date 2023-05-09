using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    public GameObject playerFlashlightObject;
    public GameObject flashlightPickup;
    public GameObject flashlightMesh;
    public CanvasGroup flashlightGetCanvasGroup;
    public bool isPickup;

    private void OnTriggerEnter(Collider other)
    {
        if (isPickup)
        {
            playerFlashlightObject.SetActive(true);
            flashlightMesh.SetActive(true);
            flashlightPickup.SetActive(false);
        }
    }

    private void Awake()
    {
        if (!isPickup)
        {
            StartCoroutine(ShowTooltip());
        }
    }
    
    private IEnumerator ShowTooltip()
    {
        flashlightGetCanvasGroup.alpha = 1.0f;
        yield return new WaitForSecondsRealtime(3f);
        flashlightGetCanvasGroup.alpha = 0f;
    }
}
