using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayCreditsButtons : MonoBehaviour
{
    public bool isPlay = false;
    public bool isCredits = false;
    public bool isExit = false;
    public float scaleAmount = 1f;

    private void OnMouseDown()
    {
        if (isPlay == true)
        {
            SceneManager.LoadScene(1);
        }

        if (isExit == true)
        {
            Application.Quit();
        }

        if (isCredits == true)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnMouseEnter()
    {
        gameObject.transform.localScale = new Vector3(scaleAmount, scaleAmount, scaleAmount);
        Debug.Log("mouse begins to hover");
    }

    private void OnMouseExit()
    {
        if (isExit == true)
        {
            gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
        else
        {
            gameObject.transform.localScale = Vector3.one;
        }

        Debug.Log("mouse exits hover");
    }
}
