using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    private float gravityValue = -9.81f;
    private bool groundedPlayer;

    public float playerSpeed = 3.0f;
    public float jumpHeight = 4.0f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
   
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if (groundedPlayer)
        {
            playerVelocity.y = -1.0f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
              playerVelocity.y += jumpHeight;
        }

        controller.Move((move * playerSpeed + playerVelocity) * Time.deltaTime);
    }
}