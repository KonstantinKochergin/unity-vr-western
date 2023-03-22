using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    public float speed = 8.0f;
    public float horizontalSpeed = 5.0f; 

    public float rotationSpeed = 1.5f;
    public float jump = 1f;
    public float Gravity = -9.8f;


    private Vector3 moveDirection;
    private Vector3 sideMoveDirection;
    private Vector3 velocity;
    private CharacterController characterController = null;

    private Vector2 turn = new Vector2();


    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") > 0.0f)
        {
            moveDirection = transform.forward * speed;
        }
        else if (Input.GetAxis("Vertical") < 0.0f)
        {
            moveDirection = -transform.forward * speed;
        }
        else
        {
            moveDirection = Vector3.zero;
        }
        turn.x += Input.GetAxis("Mouse X") * rotationSpeed;
        turn.y += Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            moveDirection += transform.right * horizontalSpeed;
        }
        else if (Input.GetAxis("Horizontal") < 0.0f && characterController.isGrounded)
        {
            moveDirection += transform.right * horizontalSpeed * -1;
        }
        //characterController.Move(moveDirection * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            velocity.y = jump;
        }
        else
        {
            velocity.y += Gravity * Time.deltaTime;
        }
        //characterController.Move(velocity * Time.deltaTime);
        Vector3 finalVector = moveDirection + velocity;
        characterController.Move(finalVector * Time.deltaTime);
    }
}

