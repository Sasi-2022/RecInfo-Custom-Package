using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float speed;
    public float jumpforce = 12f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    public float groundDistance = 0.2f;
    public float turnSmoothVelocity;
    private Vector3 velocity;
    


    void Update()
    {
        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if( isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }
           float horizontal = Input.GetAxisRaw("Horizontal");
           float vertical = Input.GetAxisRaw("Vertical");
           Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(direction * speed * Time.deltaTime);
        }

        Debug.Log($"{controller.isGrounded}");
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = jumpforce;
        }

        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }


       // velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
    }
     

}








        
        
    

