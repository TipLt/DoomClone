using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed = 10f;
    public float momentumDamping = 5f;
    private CharacterController myController;

    public Animator camAnim;
    private bool isWalking;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float gravity = -10f;


    void Start()
    {
        myController = GetComponent<CharacterController>();
    }


    void Update()
    {
        GetInput();
        MovePlayer();
       // CheckForHeadBob();

        camAnim.SetBool("isWalking", isWalking);
    }
    /*
    private void CheckForHeadBob()
    {
        if (myController.velocity.magnitude > 0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
    */
    private void GetInput()
    {

        //if we are giving input, set the input vector accordingly (-1,0,1)

        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);

            isWalking = true;
        }
        else
        {
            //if we are not giving any input, gradually reduce the input vector to zero
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);
        }


        movementVector = (inputVector * playerSpeed) + (Vector3.up * gravity);
        isWalking = false;
    }

    private void MovePlayer()
    {
        myController.Move(movementVector * Time.deltaTime);
    }
}
