using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Controllers
    public CharacterController controller;
    PlayerInputActions inputActions; 


    //Movement Stuff
    float xMoveValue;     float zMoveValue;     public float moveSpeed = 1f; 
    Vector2 movementInput;

    //Attack Stuff
    public GameObject projectile;
    public float shootForce = 5f;

    //Camera
    [SerializeField] Camera cam;
    [SerializeField] float xOffset;
    [SerializeField] float zOffset;
    [SerializeField] float zOffsetAdd;
    [SerializeField] float xoffsetAdd;
    [SerializeField] float smoothTime;

    //Door and Key
    int[] keys;
    int counter;

    private void Start()
    {
        inputActions = new PlayerInputActions();         inputActions.Enable();         inputActions.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();         inputActions.Player.Move.canceled += ctx => movementInput = ctx.ReadValue<Vector2>();
        // inputActions.Player.Attack.performed += ctx => Attack();

        keys = new int[10];
    }

    // Update is called once per frame
    void Update()
    {
        //rotation
        //Vector3 mousePos = Input.mousePosition;
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 5.23f;

        Vector3 objectPos = cam.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));



        //Move
        xMoveValue = movementInput.x * moveSpeed;
        zMoveValue = movementInput.y * moveSpeed;




        controller.Move(new Vector3(xMoveValue * Time.fixedDeltaTime, 0f , zMoveValue * Time.fixedDeltaTime));

        //Camera

        xOffset = transform.right.x * 2;
        zOffset = transform.right.z * 2;
        var targetPosition = new Vector3(transform.position.x + (xOffset + xoffsetAdd), cam.transform.position.y, transform.position.z + zOffset + (zOffsetAdd));
        cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, smoothTime);
        //Debug.Log(transform.right);

        //Input
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }



    void Attack()
    {
        // Instantiate the projectile at the position and rotation of this transform
        //Debug.Log("What");

        var clone = Instantiate(projectile, transform.position, transform.rotation);

        // Add force to the cloned object in the object's forward direction
        clone.GetComponent<Rigidbody>().AddForce(clone.transform.right * shootForce); //I dont uderstand world directions fml
    }

    public void AddKeyID(int keyID)
    {
        keys[counter] = keyID;
        counter++;
    }


    public bool SearchForKey (int keyID)
    {
        for (var i = 0; i < keys.Length; i++)
           {
                if (keys[i] == keyID)
                {
                    return true;
                }
            }

        return false;
     
    }
}
