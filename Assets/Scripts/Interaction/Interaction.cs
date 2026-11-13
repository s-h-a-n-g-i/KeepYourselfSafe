using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
interface I_Interactive
{
    public void Interacted();
    public bool usable();
}
public class Interaction : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject crosshairUse;
    public Transform interactionTransform;
    public float interactionRange;

    private InputAction interactionButtonPressed;

    private void Start()
    {
        interactionButtonPressed = InputSystem.actions.FindAction("LMB");
    }

    void Update()
    {
        InteractionUsed();
        isInInteractionRange();
    }

    private void InteractionUsed()
    {
        float buttonPressed = interactionButtonPressed.ReadValue<float>();
        if (buttonPressed>0)
        {
            Ray raycastCheckObject = new Ray(interactionTransform.position, interactionTransform.forward * interactionRange);
            if (Physics.Raycast(raycastCheckObject, out RaycastHit hit, interactionRange))
                if (hit.collider.gameObject.TryGetComponent(out I_Interactive interactiveObject)) interactiveObject.Interacted();
        }
    }


    private void isInInteractionRange()
    {
        Ray raycastCheckObject = new Ray(interactionTransform.position, interactionTransform.forward);
        if (Physics.Raycast(raycastCheckObject, out RaycastHit hit, interactionRange))
        {
            if (hit.collider.gameObject.TryGetComponent(out I_Interactive interactiveObject))
                crosshair.SetActive(true);
            else
                crosshair.SetActive(false);
        }
        else
        { crosshair.SetActive(false); }
    }
}