using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPScontroller : MonoBehaviour
{
   
    
    private CharacterController characterController;
    private Vector3 direction;
    public float speed = 10f;
    public float jumpforce = 12f;
    public float gravity = -20.0f;
    public Transform groundcheck;
    public LayerMask groundlayer;

    void Start()
    {
       
        characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
      
      
        
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        direction.x = hInput*speed;
        direction.z = vInput*speed;
       
        bool isGrounded = Physics.CheckSphere(groundcheck.position, 0.3f, groundlayer);
        if (Input.GetButton("Jump") &&  characterController.isGrounded)
        {
            direction.y = jumpforce;
           
        }
       


        if (!characterController.isGrounded)
        {
            direction.y -= gravity * Time.deltaTime;
        }


        

        characterController.Move(direction * Time.deltaTime);
        
        
            

        

    }
}
