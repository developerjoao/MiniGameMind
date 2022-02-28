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
    bool moving = false;
    bool canJump = true;
    bool isJumping = false;
    bool interacting = false;
    void MoveState()
    {
        if(canJump && Input.GetKeyDown("space") && IsGrounded())
        {
            Jump();
        }
        
        if(isJumping && Mathf.Floor(playerRB.velocity.y) == 0)
        {
            Land();
        }

        if(!interacting && Input.GetKeyDown(KeyCode.E) && !moving)
        {
            Interact();
        }
        if(canMove)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        if(movementVector.magnitude > 0)
        {
            moving = true;
            transform.rotation = Quaternion.LookRotation(movementVector);
            playerAnim.SetBool("isMoving", true);
            transform.position = transform.position + (movementVector * moveSpeed * Time.deltaTime);
        }else{
            moving = false;
            playerAnim.SetBool("isMoving", false);
        }
    }

    public float jumpForce = 5f;
    void Jump()
    {
    
        canJump = false;
        isJumping = true;

        playerAnim.SetBool("isJumping", true);
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void Land()
    {
        isJumping = false;
        playerAnim.SetBool("isJumping", false);
    }

    public bool IsGrounded()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit))
        {
            if(hit.transform.CompareTag("Ground"))
            {
                return true;
            }else{
                return false;
            }
        }else{
            return false;
        }
    }
    
    public void EnableMovement()
    {
        canMove = true;
        canJump = true;
    }

    public void DisableMovement()
    {
        canJump = false;
        canMove = false;
    }

    public void ToggleJump()
    {
        if(canJump)
        {
            canJump = false;
        }else{
            canJump = true;
        }
    }

    void Interact()
    {
        playerAnim.SetBool("isInteracting", true);
    }
    public void FinishInteractAnim()
    {
        playerAnim.SetBool("isInteracting", false);
    }
}
