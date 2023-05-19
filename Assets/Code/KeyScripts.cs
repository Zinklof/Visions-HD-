using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class KeyScripts : MonoBehaviour
{
    public bool key = true;
    public GameObject keyObject;
    public GameObject basementEntrance;
    public TMP_Text text;

    public bool keyObtained = false;

    private void OnTriggerEnter(Collider other)
    {
        if (key && !keyObtained)
        {
            StartCoroutine(PickupProcess());
        }
        else if (!key && keyObtained)
        {
            SceneManager.LoadScene(4);
        }
    }
    public IEnumerator PickupProcess()
    {
        keyObtained = true;
        var basementScript = basementEntrance.GetComponent<KeyScripts>();
        basementScript.keyObtained = true;
        keyObject.SetActive(false);
        text.text = "You have obtained a mysterious key";
        yield return new WaitForSecondsRealtime(4f);
        text.text = "";
    }
}
