using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForAnim());
    }


    IEnumerator WaitForAnim()
    {
        Debug.Log("Game Started");
        yield return new WaitForSeconds(20);
        Debug.Log("Switching Scene");
        SceneManager.LoadScene(2);
    }
}
