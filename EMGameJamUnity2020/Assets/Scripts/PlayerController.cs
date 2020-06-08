using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    PlayerInputActions inputActions; 
    Vector2 movementInput;


    float xMoveValue;     float zMoveValue;     public float moveSpeed = 1f;

    private void Start()
    {
        inputActions = new PlayerInputActions();         inputActions.Enable();         inputActions.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();         inputActions.Player.Move.canceled += ctx => movementInput = ctx.ReadValue<Vector2>();         //inputActions.Player.Attack.performed += ctx => Attack();
    }

    // Update is called once per frame
    void Update()
    {
        //rotation
        //Vector3 mousePos = Input.mousePosition;
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));



        //Move
        xMoveValue = movementInput.x * moveSpeed;
        zMoveValue = movementInput.y * moveSpeed;




        controller.Move(new Vector3(xMoveValue * Time.fixedDeltaTime, 0f , zMoveValue * Time.fixedDeltaTime));
    }
}
