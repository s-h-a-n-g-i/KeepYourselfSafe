using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    //[HideInInspector]

    public bool isCutScene = false;
    [SerializeField] private Camera cameraPlayer;

    [Header("Walking Settings")]
    [SerializeField] private float walkSpeed = 6f;
    [SerializeField] private float gravity = 11.9f;
    [SerializeField] private float vievlimit = 80f;

    public float sens = 2f;
    [Header("Crouch Settings")]
    [SerializeField] private float normalHeight = 2f;
    [SerializeField] private float crouchHeight = 0.7f;

    private InputAction move; 
    private InputAction mouseLook;
    private InputAction crouch;

    //[SerializeField] private LayerMask wallsLayerMask;

    private float speed = 0;

    public bool moving = false;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    public bool lockCamera = false;

    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        mouseLook = InputSystem.actions.FindAction("Look");
        crouch = InputSystem.actions.FindAction("Crouch");
        speed = walkSpeed;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (isCutScene) return; 
        Walking();
        Crouchin();
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
        if (!lockCamera)
        {
            cameraPlayer.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, mouseVector.x * sens, 0);
        }
    }

    private void Crouchin()
    {
        characterController.height = crouch.ReadValue<float>() > 0 ? crouchHeight : normalHeight;
        cameraPlayer.transform.localPosition = new Vector3(0, crouch.ReadValue<float>() > 0 ? crouchHeight/2 : normalHeight/2, 0);
    }


}