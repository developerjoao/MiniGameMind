using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Animator playerAnim;

    Rigidbody playerRB;
    public float moveSpeed = 5f;

    float xInput;
    float yInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update()
    {
        MoveState();
    }

    bool canMove = true;
    bool canJump = true;
    void MoveState()
    {
        if(canJump && Input.GetKeyDown("space"))
        {
            Jump();
        }

        Move();
    }

    void Move()
    {
        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        if(movementVector.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(movementVector);
            playerAnim.SetBool("isMoving", true);
            transform.position = transform.position + (movementVector * moveSpeed * Time.deltaTime);
        }else{
            playerAnim.SetBool("isMoving", false);
        }
    }

    public float jumpForce = 5f;
    void Jump()
    {
        canMove = false;
        canJump = false;

        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    
}
