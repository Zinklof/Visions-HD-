using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    [Header("transforms")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject monster;
    [SerializeField] private Rigidbody rb;

    [Header("speeds")]
    [SerializeField] private float approachSpeed;
    [SerializeField] private float chaseSpeed;

    [Header("teleports")]
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    [SerializeField] private Transform pos3;
    [SerializeField] private Transform pos4;
    [SerializeField] private Transform pos5;

    private float distanceFromPlayer;
    private float currentSpeed;
    private Vector3 moveDirection;
    private string status;



    private void LookAtPlayer()
    {
        //rotate the doggo to look at player
        monster.transform.LookAt(player.transform);
    }

    private void MoveTowardsPlayer()
    {
        //get distance from player
        distanceFromPlayer = Vector3.Distance(player.transform.position, monster.transform.position);

        if (distanceFromPlayer < 25f && distanceFromPlayer > 6f)
        {
            status = "chase";
            rb.AddRelativeForce(new Vector3(0f, 0f, 1f) * chaseSpeed);
        }
        else
            rb.AddRelativeForce(new Vector3(0f, 0f, 1f) * approachSpeed);
    }

    private void TeleportMonster()
    {
        if (distanceFromPlayer < 6f)
        {
            Debug.Log("teleporte!");
            monster.transform.position = pos1.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        MoveTowardsPlayer();
        TeleportMonster();
    }
}
