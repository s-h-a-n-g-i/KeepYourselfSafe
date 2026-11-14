using UnityEngine;
using UnityEngine.InputSystem;

interface I_InteractiveOpenClose
{
    public void Interacted();
}

public class InteractionOpenClose : MonoBehaviour
{
    public GameObject crosshair;
    public Transform interactionTransform;
    public float interactionRange;

    private InputAction interactionButtonPressed;

    private void Start()
    {
        interactionButtonPressed = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        InteractionUsed();
        isInInteractionRange();
    }

    private void InteractionUsed()
    {
        float buttonPressed = interactionButtonPressed.ReadValue<float>();
        if (buttonPressed > 0)
        {
            Ray raycastCheckObject = new Ray(interactionTransform.position, interactionTransform.forward * interactionRange);
            if (Physics.Raycast(raycastCheckObject, out RaycastHit hit, interactionRange))
                if (hit.collider.gameObject.TryGetComponent(out I_InteractiveOpenClose interactiveObject)) interactiveObject.Interacted();
        }
    }


    private void isInInteractionRange()
    {
        Ray raycastCheckObject = new Ray(interactionTransform.position, interactionTransform.forward);
        if (Physics.Raycast(raycastCheckObject, out RaycastHit hit, interactionRange))
        {
            if (hit.collider.gameObject.TryGetComponent(out I_InteractiveOpenClose interactiveObject))
                crosshair.SetActive(true);
        }
        else
            crosshair.SetActive(false);
    }
}
