using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ItemGrab : MonoBehaviour, I_Interactive
{
    private Rigidbody rb;
    private Transform player;

    [SerializeField] private bool isInteracting;
    [SerializeField] private bool isUsable;
    private InputAction lmb;
    public void Interacted()
    {
        rb.useGravity = false;
        transform.SetParent(player);
        isInteracting = true;
    }

    void Start()
    {
        lmb = InputSystem.actions.FindAction("LMB");
        player = GameObject.Find("Main Camera").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isInteracting) EndInteraction();
    }

    private void EndInteraction() 
    {
        float buttonPressed = lmb.ReadValue<float>();
        if (buttonPressed > 0) return;
        isInteracting = false;
        transform.SetParent(null);
        rb.useGravity = true;

    }


    private void RotateObject() 
    {
        
    }

    public void UseItem() 
    {
        
    }


}
