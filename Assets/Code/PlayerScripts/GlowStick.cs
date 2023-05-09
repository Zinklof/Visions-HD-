using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowStick : MonoBehaviour
{
    public GameObject glowstickPrefab;
    public GameObject Player;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            GameObject throwstick = (GameObject)Instantiate(glowstickPrefab, Player.transform.position, Player.transform.rotation);
            throwstick.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, 0f, 500f));
        }
    }
}
