using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Objects")]
    public GameObject playerObject;
    [SerializeField] public CharacterController controller;

    private float playerSpeed = 3f;
    private float stamina = 100f;
    private float maxStamina = 100f;
    private float sprintSpeed = 7f;
    private float horizontalInput;
    private float verticalInput;
    private float gravity = 0f;
    private bool playerRunning;
    private Vector3 moveDirection;

    [Header("UI Elements")]
    public Image staminaBarUi = null;
    public CanvasGroup sprintCanvasGroup = null;

    //moves the player in all directions using physics, also jumps
    void Movement()
    {
        //set input floats
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //set move direction vector3
        moveDirection = (transform.forward * verticalInput) + (transform.right * horizontalInput);

        //gravity
        if (controller.isGrounded)
        {
            gravity = -0.5f;
        }
        else
            //calculate gravity
            gravity += Physics.gravity.y * Time.deltaTime;

        //move player
        moveDirection.y = gravity;
        //if (Input.GetKey(KeyCode.LeftShift) && stamina > 0.5f)
            //controller.Move(moveDirection * sprintSpeed * Time.deltaTime);
            controller.Move(moveDirection * playerSpeed * Time.deltaTime);
    }

    void SprintCheck()
    {
        //test for sprint
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0.5f)
        {
            playerRunning = true;
        }
        else
        {
            playerRunning = false;
        }
    }

    void Running()
    {
        //set input floats
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //set move direction vector3
        moveDirection = (transform.forward * verticalInput) + (transform.right * horizontalInput);

        controller.Move(moveDirection * sprintSpeed * Time.deltaTime);
    }

    void StaminaDrain()
    {
        if (playerRunning == true)
        {
            stamina -= 0.2f;
        }

        if (playerRunning == false)
        {
            stamina += 0.15f;
        }

        if (stamina <= 0f)
        {
            stamina = 0f;
        }

        if (stamina > 100f)
        {
            stamina = 100f;
        }

        staminaBarUi.fillAmount = stamina / maxStamina;
    }

    void SprintBarClear()
    {
        if (stamina >= 99.9)
            sprintCanvasGroup.alpha = 0f;
        else
            sprintCanvasGroup.alpha = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        StaminaDrain();
        //SprintCheck();
        SprintBarClear();

        //if (playerRunning == true && stamina > 0.5f)
            //Running();
        //if (playerRunning == false || stamina < 0.5f)
            Movement();
    }
}
