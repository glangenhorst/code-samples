using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControllerScript : MonoBehaviour
{
    // Based on several FPS tutorials
    CharacterController playerController;

    public GameObject eyesCam;

    public float speed = 2f, sensitivity = 2f, jumpForce = 4f, localGrav = 1f;

    private float moveFB, moveLR, rotX, rotY, vertVelocity;

    private bool hasJumped, isCrouched;

    //invert camera stuff
    bool isInverted = false;
    int invertOnNegOne = 1;
    //

    void Start() {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerController = GetComponent<CharacterController> ();
    }

    void Update() {
        //WASD + mouselook
        Movement();

        //jump
        if (Input.GetButtonDown("Jump"))
        {
            hasJumped = true;
        }

        //crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!isCrouched)
            {
                playerController.height = playerController.height / 2;
                isCrouched = true;
            }
            else
            {
                playerController.height = playerController.height * 2;
                isCrouched = false;
            }
        }

        ApplyGravity();
    }

    public void Movement()
    {
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -60f, 60f);

        Vector3 movementVec = new Vector3(moveLR, vertVelocity, moveFB);
        transform.Rotate(0, rotX, 0);
        eyesCam.transform.localRotation = Quaternion.Euler(rotY * invertOnNegOne, 0, 0);

        movementVec = transform.rotation * movementVec;
        playerController.Move(movementVec * Time.deltaTime);
    }

    public void invertLook()
    {
        //call to invert cameralook
        //switches immediately
        if (!isInverted){
            invertOnNegOne = -1;
            Debug.Log("look inverted");
            isInverted = true;
        }
        else
        {
            invertOnNegOne = 1;
            Debug.Log("look normalized");
            isInverted = false;
        }
    }

    public void ApplyGravity()
    {
        if (playerController.isGrounded)
        {
            if (!hasJumped)
            {
                vertVelocity = Physics.gravity.y * localGrav;
            }
            else
            {
                vertVelocity = jumpForce;
            }
        }
        else
        {
            vertVelocity += Physics.gravity.y * localGrav * Time.deltaTime;
            vertVelocity = Mathf.Clamp(vertVelocity, -50f, jumpForce);
            hasJumped = false;
        }
    }
}
