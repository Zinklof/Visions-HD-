using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public bool isBackButton = false;
    public float scaleAmount = 1f;
    public Animator animator;

    private void OnMouseDown()
    {
        if (isBackButton == true)
        {
            animator.SetBool("InSettings", false);
        }

        if (isBackButton == false)
        {
            animator.SetBool("InSettings", true);
        }
    }

    private void OnMouseEnter()
    {
        gameObject.transform.localScale = new Vector3(scaleAmount, scaleAmount, scaleAmount);
        Debug.Log("mouse begins to hover");
    }
    private void OnMouseExit()
    {
        gameObject.transform.localScale = Vector3.one;
        Debug.Log("mouse exits hover");
    }
}
