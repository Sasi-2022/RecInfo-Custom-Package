using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    PlayerControls1 controls1;
    PlayerControls1.GroundMovementActions groundMovement;
    Vector2 horizontalInput;
    Vector2 mouseInput;
    private void Awake()
    {
        controls1 = new PlayerControls1();
        groundMovement = controls1.GroundMovement;
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.Jump.performed += _ => movement.OnJumpPressed();
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();


    }

    private void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
    }
    private void OnEnable()
    {
        controls1.Enable();
    }

    private void OnDestroy()
    {
        controls1.Disable();
    }
}
