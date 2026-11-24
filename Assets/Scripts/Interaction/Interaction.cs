using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
interface I_Interactive
{
    public void Interacted();
    public GameObject GetGameObject();
    public void EndInteraction();
    public bool usable();
}
public class Interaction : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject crosshairUse;
    public Transform interactionTransform;
    public float interactionRange;

    private InputAction interactionButtonPressed;
    private GameObject interactedObject;
    private void Start()
    {
        interactionButtonPressed = InputSystem.actions.FindAction("LMB");
    }

    void Update()
    {
        float buttonPressed = interactionButtonPressed.ReadValue<float>();

        if (buttonPressed > 0)
        {
            InteractionUsed();
        }
        else if(interactedObject != null)
        {
            InteractionEnded();
        }
            isInInteractionRange();
    }

    private void InteractionUsed()
    {
        
        Ray raycastCheckObject = new Ray(interactionTransform.position, interactionTransform.forward * interactionRange);
        if (Physics.Raycast(raycastCheckObject, out RaycastHit hit, interactionRange))
            if (hit.collider.gameObject.TryGetComponent(out I_Interactive interactiveObject))
            {
                interactiveObject.Interacted();
                interactedObject = interactiveObject.GetGameObject();
            }
       
    }


    private void isInInteractionRange()
    {
        Ray raycastCheckObject = new Ray(interactionTransform.position, interactionTransform.forward);
        if (Physics.Raycast(raycastCheckObject, out RaycastHit hit, interactionRange))
        {
            if (hit.collider.gameObject.TryGetComponent(out I_Interactive interactiveObject))
                if (interactiveObject.usable())
                {
                    crosshair.SetActive(false);
                    crosshairUse.SetActive(true);
                }
                else
                {
                    crosshair.SetActive(true);
                    crosshairUse.SetActive(false);
                }
            else
            {
                crosshair.SetActive(false);
                crosshairUse.SetActive(false);
            }
        }
        else
        { crosshair.SetActive(false); }
    }

    private void InteractionEnded() 
    {
        interactedObject.GetComponent<I_Interactive>().EndInteraction();
        interactedObject = null;
    }
}