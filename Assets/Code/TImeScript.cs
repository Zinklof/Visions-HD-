using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TImeScript : MonoBehaviour
{

    public int seconds = 0;
    public int minutes = 0;
    public int hours = 0;

    public TMP_Text secondsText;
    public TMP_Text minutesText;
    public TMP_Text hoursText;

    private void Start()
    {
        StartCoroutine(TimeManager());
    }

    private IEnumerator TimeManager()
    {
        yield return new WaitForSecondsRealtime(1);
        seconds += 1;
        StartCoroutine(TimeManager());
    }

    private void Update()
    {
        if (seconds >= 60)
        {
            minutes += 1;
            seconds = 0;
        }
        if (minutes >= 60)
        {
            hours += 1;
            minutes = 0;
        }

        if (seconds < 10)
            secondsText.text = "0" + seconds.ToString();
        else
            secondsText.text = seconds.ToString();

        if (minutes < 10)
            minutesText.text = "0" + minutes.ToString();
        else
            minutesText.text = minutes.ToString();

        if (hours < 10)
            hoursText.text = "0" + hours.ToString();
        else
            hoursText.text = hours.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);

            
    }

}
