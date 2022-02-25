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
        //Movimento usando transform position
        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        if(movementVector.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(movementVector);
            playerAnim.SetBool("isMoving", true);
            transform.position = transform.position + (movementVector * moveSpeed * Time.deltaTime);
        }else{
            playerAnim.SetBool("isMoving", false);
        }

        //Movimento usando velocity
        /*
        playerRB.velocity = new Vector3(
			Mathf.Lerp(0, Input.GetAxis("Horizontal")* moveSpeed, 0.8f),
			playerRB.velocity.y,
			Mathf.Lerp(0, Input.GetAxis("Vertical")* moveSpeed, 0.8f)
		);*/
    }
}
