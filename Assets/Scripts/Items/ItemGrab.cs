using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class ItemGrab : MonoBehaviour, I_Interactive
{
    private Rigidbody rb;
    private Transform player;

    [SerializeField] private bool isInteracting;
    [SerializeField] private bool isUsable;
    private InputAction lmb;
    private InputAction rmb;
    private InputAction interaction;
    private InputAction mouseLook;
    //private InputAction interact;

    private PlayerMovement movement;

    private Vector3 prevPos;
    private bool itemUsedOnce = false;
    void Start()
    {


        movement = GameObject.FindFirstObjectByType<PlayerMovement>();

        interaction = InputSystem.actions.FindAction("Interact");
        mouseLook = InputSystem.actions.FindAction("Look");
        lmb = InputSystem.actions.FindAction("LMB");
        rmb = InputSystem.actions.FindAction("RMB");
        //interact = InputSystem.actions.FindAction("Interact");

        player = GameObject.Find("Main Camera").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
            float rmbClicked = rmb.ReadValue<float>();
        if (isInteracting)
        {
            EndInteraction();
            float interactionClicked = interaction.ReadValue<float>();

            if (interactionClicked > 0 && !itemUsedOnce)
            {
                UseItem();
                itemUsedOnce = true;
            }
            else if (!(interactionClicked > 0))
                itemUsedOnce = false;

            if (rmbClicked > 0 && isInteracting)
                RotateObject();
            else
                EndRotateObject();
        }

        if (transform.position.y < -1)
            transform.position = prevPos;
    }

    private void EndInteraction() 
    {
        float buttonPressed = lmb.ReadValue<float>();
        if (buttonPressed > 0) return;
        EndRotateObject();
        isInteracting = false;
        transform.SetParent(null);
        rb.useGravity = true;
        GetComponent<BoxCollider>().isTrigger = false;

    }


    private void RotateObject()
    {
        Vector2 mouseVector = mouseLook.ReadValue<Vector2>();

        movement.lockCamera = true;

        transform.localRotation *= Quaternion.Euler(mouseVector.y * movement.sens, mouseVector.x * movement.sens, 0);

    }
    private void EndRotateObject()
    {
        movement.lockCamera = false;
    }

    virtual public void UseItem() 
    {
        
    }
    
    public void Interacted()
    {
        if(!isInteracting)
            prevPos = transform.position;
        GetComponent<BoxCollider>().isTrigger = true;
        rb.useGravity = false;
        rb.angularVelocity = Vector3.zero;
        rb.linearVelocity = Vector3.zero;
        transform.SetParent(player);
        isInteracting = true;
    }

    public bool usable()
    {
        return isUsable;
    }
}
