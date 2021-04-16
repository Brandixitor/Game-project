using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float Mass;
    public float MovementSpeed;
    public float JumpForce;
    public bool isGrounded;
    public LayerMask layerMask;
    private Rigidbody rb;

    private void Start() {

        rb = GetComponent<Rigidbody>();

    }

    private void Update() {

        float x = Input.GetAxisRaw("Horizontal") * MovementSpeed;
        float y = Input.GetAxisRaw("Vertical") * MovementSpeed;

        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, layerMask);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {

            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);

        }

        if(!isGrounded) {

            rb.velocity -= new Vector3(0, Mass, 0);

        }

        Vector3 movePos = transform.right * x + transform.forward * y;
        Vector3 newMovePos = new Vector3(movePos.x, rb.velocity.y, movePos.z);

        rb.velocity = newMovePos;

    }

}
