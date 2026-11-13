using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[HideInInspector]
    public bool isCutScene = false;

    [SerializeField] private Camera cameraPlayer;
    [SerializeField] private float walkSpeed = 6f;
    [SerializeField] private float gravity = 11.9f;


    [SerializeField] private float sens = 2f;

    [SerializeField] private float vievlimit = 90f;


    //[SerializeField] private LayerMask wallsLayerMask;

    private float speed = 0;

    public bool moving = false;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;



    void Start()
    {
        speed = walkSpeed;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        if (!isCutScene) Walking();
    }





    private void Walking()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = (speed) * Input.GetAxis("Vertical");
        float curSpeedY = (speed) * Input.GetAxis("Horizontal");

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


        rotationX += -Input.GetAxis("Mouse Y") * sens;
        rotationX = Mathf.Clamp(rotationX, -vievlimit, vievlimit);
        cameraPlayer.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sens, 0);

    }



}