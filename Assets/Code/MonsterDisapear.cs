using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDisapear : MonoBehaviour
{
    public bool glowstick = false;
    public bool dogJump = false;
    public GameObject freahm;

    private void OnTriggerEnter(Collider other)
    {
        if(!dogJump)
        gameObject.SetActive(false);

        if (dogJump)
            StartCoroutine(FreahmJumpscare());
    }

    private void Awake()
    {
        if (glowstick)
        {
            StartCoroutine(Despawn());
        }
    }


    IEnumerator FreahmJumpscare()
    {
        freahm.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        freahm.SetActive(false);
    }
    IEnumerator Despawn()
    {
        yield return new WaitForSecondsRealtime(5f);
        GameObject.Destroy(gameObject);
    }
}
