using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    //[HideInInspector]
    public bool isCutScene = false;

    [SerializeField] private Camera cameraPlayer;
    [SerializeField] private float walkSpeed = 6f;
    [SerializeField] private float gravity = 11.9f;


    [SerializeField] private float sens = 2f;

    [SerializeField] private float vievlimit = 80f;

    private InputAction move; 
    private InputAction mouseLook; 

    //[SerializeField] private LayerMask wallsLayerMask;

    private float speed = 0;

    public bool moving = false;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;



    void Start()
    {
        move = InputSystem.actions.FindAction("Move"); 
        mouseLook = InputSystem.actions.FindAction("Look"); 
        speed = walkSpeed;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (isCutScene) return; 
        Walking();
    }





    private void Walking()
    {
        Vector2 moveVector = move.ReadValue<Vector2>();
        Vector2 mouseVector = mouseLook.ReadValue<Vector2>();

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = (speed) * moveVector.y;
        float curSpeedY = (speed) * moveVector.x;

        moveDirection.x = (forward * curSpeedX).x + (right * curSpeedY).x;
        moveDirection.z = (forward * curSpeedX).z + (right * curSpeedY).z;

        if (characterController.isGrounded)
        {
            if (moveDirection.y < 0)
                moveDirection.y = -2f;
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }


        characterController.Move(moveDirection * Time.deltaTime);

        moving = (curSpeedX > 0 || curSpeedY > 0 || curSpeedX < 0 || curSpeedY < 0 ? true : false);



        rotationX += -mouseVector.y * sens;
        rotationX = Mathf.Clamp(rotationX, -vievlimit, vievlimit);
        cameraPlayer.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseVector.x * sens, 0);

    }



}